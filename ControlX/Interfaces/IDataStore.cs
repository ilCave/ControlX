using System;
using System.Threading.Tasks;

namespace ControlX.Interfaces
{
    public interface IDataStore<T>: IDisposable where T:  DocsMarshal.MVVM.Models.BaseModelEntity
    {
        Task<DocsMarshal.Entities.ProfileInserted> Insert(T model, bool raiseWorkflowEvents);
        Task<DocsMarshal.Entities.ProfileUpdated> Update(T model, bool raiseWorkflowEvents);
        Task<DocsMarshal.Entities.ProfileDeleted> Delete(T model);
    }
}
