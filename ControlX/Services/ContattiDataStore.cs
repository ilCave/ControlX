using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlX.Models;
using DocsMarshal.Entities;
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



        internal override ProfileForInsert FromEntityToProfileForInsert(Contatto model, bool raiseWorkflowEvents)
        {
            var insert = model.ToProfileForInsert(raiseWorkflowEvents);

            insert.Fields.Add(new FieldValueString("Nome", model.Nome));
            insert.Fields.Add(new FieldValueString("Telefono", model.Telefono));
            insert.Fields.Add(new FieldValueString("Email", model.Email));
            insert.Fields.Add(new FieldValueString("Cognome", model.Cognome));
            insert.Fields.Add(new FieldValueBoolean("OkPubblicita", model.OkPubb));
            insert.Fields.Add(new FieldValueBoolean("OkAlertOffTaglio", model.OkAlertOffTaglio));
            insert.Fields.Add(new FieldValueString("UserName", model.UserName));
            insert.Fields.Add(new FieldValueString("Cellulare", model.Cellulare));
            insert.Fields.Add(new FieldValueBoolean("OkInvioAvvisi", model.OkInvioAvvisi));
            insert.Fields.Add(new FieldValueString("QrCodeRegistrazione", model.QrCodeRegistrazione));
            insert.Fields.Add(new FieldValueDateTime("QrCodescadenza", model.QrCodeScadenza,""));
            insert.Fields.Add(new FieldValueString("NotePubbliche", model.NotePubbliche));
            insert.Fields.Add(new FieldValueString("NotePrivate", model.NotePrivate));
            insert.Fields.Add(new FieldValueString("Sesso", model.Sesso));
            insert.Fields.Add(new FieldValueDateTime("dtnascita", model.DataNascita, ""));
            insert.Fields.Add(new FieldValueString("password", model.Password));
            return insert;
        }
    }
}
