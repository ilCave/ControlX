using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlX.Models;
using DocsMarshal.Entities.Interfaces;
using DocsMarshal.Interfaces;

namespace ControlX.Services
{
    public class ContattiDataStore: AbstractDataStore<Models.Contatto>
    {

        public ContattiDataStore(IManager manager, string classtypeExternalId) : base(manager, classtypeExternalId)
        {
        }

        public override Contatto Filler(IProfile profile)
        {
            var ritorno = new Models.Contatto();
            ritorno.LoadStandardFieldFromProfileSearchResult(profile);
            ritorno.Nome = profile.GetStringValue_By_ExternalId("Nome");
            ritorno.Telefono = profile.GetStringValue_By_ExternalId("Telefono");
            ritorno.Email = profile.GetStringValue_By_ExternalId("Email");
            ritorno.Cognome = profile.GetStringValue_By_ExternalId("Cognome");
            ritorno.OkPubb = profile.GetBoolValue_By_ExternalId("OkPubblicita").GetValueOrDefault();
            ritorno.OkAlertOffTaglio = profile.GetBoolValue_By_ExternalId("OkAlertOffTaglio").GetValueOrDefault();
            ritorno.UserName = profile.GetStringValue_By_ExternalId("UserName");
            ritorno.Cellulare = profile.GetStringValue_By_ExternalId("Cellulare");
            ritorno.OkInvioAvvisi = profile.GetBoolValue_By_ExternalId("OkInvioAvvisi").GetValueOrDefault();
            ritorno.QrCodeRegistrazione = profile.GetStringValue_By_ExternalId("QrCodeRegistrazione");
            ritorno.QrCodeScadenza = profile.GetDateTimeValue_By_ExternalId("QrCodescadenza");
            ritorno.NotePubbliche = profile.GetStringValue_By_ExternalId("NotePubbliche");
            ritorno.NotePrivate = profile.GetStringValue_By_ExternalId("NotePrivate");
            ritorno.Sesso = profile.GetStringValue_By_ExternalId("Sesso");
            ritorno.RefIdSaloni = profile.GetStringValue_By_ExternalId("RefIdSaloneMulti");
            ritorno.DataNascita = profile.GetDateValue_By_ExternalId("dtnascita");
            ritorno.Password = profile.GetStringValue_By_ExternalId("password");
            return ritorno;
        }

        public override Task<IEnumerable<Contatto>> GetLastItemsUpdatesAsync(DateTime? lastUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
