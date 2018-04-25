using System;
using System.Collections.Generic;
using DocsMarshal.Entities.Interfaces;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace ControlX.Services
{
    public abstract class AbstractDataStore<T> : Interfaces.IDataStore<T> where T :  DocsMarshal.MVVM.Models.BaseModelEntity, new()
    {
        internal DocsMarshal.Interfaces.IManager Manager { get; private set; }

        public SQLite.SQLiteAsyncConnection Connection => DependencyService.Get<Persistence.ISQLiteDb>().GetConnection();
        internal List<T> items { get; set; }
        internal string ClassTypeExternalId { get; private set; }

        public AbstractDataStore(DocsMarshal.Interfaces.IManager manager, string classtypeExternalId)
        {
            Manager = manager;
            ClassTypeExternalId = classtypeExternalId;
        }

       
        public virtual void Dispose()
        {

        }

        public abstract T Filler(IProfile profile);

       
        public virtual async Task<DocsMarshal.Entities.ProfileDeleted> Delete(T model)
        {
            try
            {
                var ritorno = await Manager.Profile.Archive.Delete(model.Objectid);
                if (!ritorno.HasError)
                {   
                    await Connection.DeleteAsync(model);
                    items.Remove(model);
                }
                return ritorno;
            }
            catch (Exception ex)
            {

                var rit = new DocsMarshal.Entities.ProfileDeleted();
                rit.HasError = true;
                rit.Error = ex.Message;
                return rit;
            }
        }


        public virtual async  Task<DocsMarshal.Entities.ProfileInserted> Insert(T model, bool raiseWorkflowEvents)
        {
            try
            {
                var profileForInsert = FromEntityToProfileForInsert(model, raiseWorkflowEvents);
                var inserted = await Manager.Profile.Archive.Insert(profileForInsert);
                if (!inserted.HasError)
                {
                    // carico i campi standard nel model
                    model.LoadStandardFieldFromProfileSearchResult(inserted.Profile);
                    items.Add(model);
                    // salovo la nuova entità nel database locale
                    await Connection.InsertOrReplaceAsync(model);
                }
                return inserted;
            }
            catch (Exception ex)
            {
               
                var rit = new DocsMarshal.Entities.ProfileInserted(null);
                rit.HasError = true;
                rit.Error = ex.Message;
                return rit;
            }
        }

        public virtual async Task<DocsMarshal.Entities.ProfileUpdated> Update(T model, bool raiseWorkflowEvents)
        {
            try
            {
                var profileForUpdate = FromEntityToProfileForUpdate(model, raiseWorkflowEvents);
                var updated = await Manager.Profile.Archive.Update(profileForUpdate);
                if (!updated.HasError)
                {
                    // carico i campi standard nel model
                    model.LoadStandardFieldFromProfileSearchResult(updated.Profile);
                    // salovo la nuova entità nel database locale
                    await Connection.InsertOrReplaceAsync(model);
                }
                return updated;
            }
            catch (Exception ex)
            {

                var rit = new DocsMarshal.Entities.ProfileUpdated(null);
                rit.HasError = true;
                rit.Error = ex.Message;
                return rit;
            }
        }

        internal abstract DocsMarshal.Entities.ProfileForInsert FromEntityToProfileForInsert(T model, bool raiseWorkflowEvents);
        internal abstract DocsMarshal.Entities.ProfileForUpdate FromEntityToProfileForUpdate(T model, bool raiseWorkflowEvents);



        public async System.Threading.Tasks.Task<T> GetItemAsync(Guid objectId)
        {
            var profilo = await Manager.Profile.Search.ById(objectId);
            var rit = profilo.GetResultAsProfiles();
            if (rit.Count == 0)
                return default(T);
            else
                return Filler(rit.First());
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            if (items == null || items.Count == 0)
            {
                items = await Connection.Table<T>().ToListAsync();
            }
            if ((items.Count == 0 || forceRefresh) && CrossConnectivity.Current.IsConnected)
            {
                if (forceRefresh)
                {
                    await Connection.DropTableAsync<T>();
                    await Connection.CreateTableAsync<T>();
                }
                var ricerca = new DocsMarshal.Entities.ProfileSearch();
                ricerca.sessionID = Manager.SessionId;
                ricerca.classTypeExternalId = ClassTypeExternalId;
                var risultato = await Manager.Profile.Search.Query.ExecuteAsync(ricerca);
                var ritorno = new List<T>();
                foreach (var elemento in risultato.GetResultAsProfiles())
                {
                    ritorno.Add(Filler(elemento));
                }
                foreach (var item in ritorno)
                    await Connection.InsertOrReplaceAsync(item);
                items = await Connection.Table<T>().ToListAsync();
            }
            return items;
        }

        public abstract Task<IEnumerable<T>> GetLastItemsUpdatesAsync(DateTime? lastUpdate);

    }
}
