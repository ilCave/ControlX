using System;
using System.Threading.Tasks;

namespace ControlX.Interfaces
{
    public interface IControlXOrchestrator: IDisposable
    {
        Services.ContattiDataStore Contatti { get; }
        Task<Models.LogOnToken> Login(string userName, string password);
    }
}
