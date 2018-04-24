using System;
using System.Collections.Generic;
using DocsMarshal.Entities.Interfaces;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace ControlX.Services
{
    public abstract class AbstractDataStore<T> : Interfaces.IDataStore<T> where T : new()
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
