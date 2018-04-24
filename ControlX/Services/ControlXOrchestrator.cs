using System;
using System.Threading.Tasks;
using ControlX.Models;

namespace ControlX.Services
{
    public class ControlXOrchestrator: Interfaces.IControlXOrchestrator
    {
        DocsMarshal.Orchestrator.Manager orchestrator;

        public ControlXOrchestrator()
        {
            orchestrator = new DocsMarshal.Orchestrator.Manager(App.BackendUrl);
            orchestrator.Logon(App.StaticSessionId, string.Format(App.CurTitle));
            Contatti = new Services.ContattiDataStore(orchestrator, "Clienti");
        }

        public ContattiDataStore Contatti { get; private set; }

        public void Dispose()
        {
            Contatti.Dispose();
            orchestrator.Dispose();
            orchestrator = null;
        }

        public async Task<LogOnToken> Login(string userName, string password)
        {
            var logon = await orchestrator.Logon(userName, password, App.CurTitle);
            if (logon != null && logon.LoggedIn)
                return new LogOnToken { Password = password, UserName = userName, SessionId = logon.SessionId.ToString() };
            return null;
        }
    }
}
