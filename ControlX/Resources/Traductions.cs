using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ControlX.Resources
{
    public class Traductions: DocsMarshal.MVVM.ViewModels.BaseViewModel
    {


        public string StrInsert { get { return GetCurvalueLang(_StrInsert); } }
        public string StrUpdate { get { return GetCurvalueLang(_StrUpdate); } }
        public string StrNome { get { return GetCurvalueLang(_StrNome); } }
        public string StrCognome { get { return GetCurvalueLang(_StrCognome); } }
        public string BtnEdit { get { return GetCurvalueLang(_BtnEdit); } }
        public string StrUserName { get { return GetCurvalueLang(_StrUserName); } }
        public string StrPassword { get { return GetCurvalueLang(_StrPassword); } }
        public string StrAccedi { get { return GetCurvalueLang(_StrAccedi); } }
        public string StrCercaContatto { get { return GetCurvalueLang(_StrCercaContatto); } }
        public string ErrUsernameOrPasswordNotValid { get { return GetCurvalueLang(_ErrUsernameOrPasswordNotValid); } }
        public string StrNumeroContatti { get { return GetCurvalueLang(_StrNumeroContatti); } }

        public string StrNomeECognome { get { return GetCurvalueLang(_StrNomeECognome); } }
        public string StrQrCodeRegistrazione { get { return GetCurvalueLang(_StrQrCodeRegistrazione); } }
        public string StrSesso { get { return GetCurvalueLang(_StrSesso); } }

        public string StrEmail { get { return GetCurvalueLang(_StrEmail); } }
        public string StrOkPubb { get { return GetCurvalueLang(_StrOkPubb); } }
        public string StrOkAlertOffTaglio { get { return GetCurvalueLang(_StrOkAlertOffTaglio); } }
        public string StrTelefono { get { return GetCurvalueLang(_StrTelefono); } }
        public string StrNotePubbliche { get { return GetCurvalueLang(_StrNotePubbliche); } }
        public string StrNotePrivate { get { return GetCurvalueLang(_StrNotePrivate); } }
        public string StrDataNascita { get { return GetCurvalueLang(_StrDataNascita); } }
        public string StrCellulare { get { return GetCurvalueLang(_StrCellulare); } }
        public string StrOkInvioAvvisi { get { return GetCurvalueLang(_StrOkInvioAvvisi); } }

        Dictionary<string, string> _StrInsert = new Dictionary<string, string>
        {
            {"IT",  "Inserisci"},
            {"EN",  "Insert"}
        };Dictionary<string, string> _StrUpdate = new Dictionary<string, string>
        {
            {"IT",  "Modifica"},
            {"EN",  "Update"}
        };
        Dictionary<string, string> _StrNome = new Dictionary<string, string>
        {
            {"IT",  "Nome"},
            {"EN",  "Name"}
        };
        Dictionary<string, string> _StrCognome = new Dictionary<string, string>
        {
            {"IT",  "Cognome"},
            {"EN",  "Surname"}
        };
        Dictionary<string, string> _BtnEdit = new Dictionary<string, string>
        {
            {"IT",  "Modifica"},
            {"EN",  "Edit"}
        };
        Dictionary<string, string> _StrQrCodeRegistrazione = new Dictionary<string, string>
        {
            {"IT",  "Codice di registrazione"},
            {"EN",  "Codice di registrazione"}
        };

        Dictionary<string, string> _StrNomeECognome = new Dictionary<string, string>
        {
            {"IT",  "Nome e cognome"},
            {"EN",  "Name and surname"}
        };


        Dictionary<string, string> _StrSesso = new Dictionary<string, string>
        {
            {"IT",  "Sesso"},
            {"EN",  "Sex"}
        };

        Dictionary<string, string> _StrEmail = new Dictionary<string, string>
        {
            {"IT",  "Email"},
            {"EN",  "Email"}
        };


        Dictionary<string, string> _StrOkPubb = new Dictionary<string, string>
        {
            {"IT",  "Avvisi promozionali prodotti"},
            {"EN",  "Avvisi promozionali prodotti"}
        };

        Dictionary<string, string> _StrOkAlertOffTaglio = new Dictionary<string, string>
        {
            {"IT",  "Avviso offerte taglio"},
            {"EN",  "Avviso offerte taglio"}
        };

        Dictionary<string, string> _StrTelefono = new Dictionary<string, string>
        {
            {"IT",  "Telefono"},
            {"EN",  "Telephone Number"}
        };

        Dictionary<string, string> _StrNotePrivate = new Dictionary<string, string>
        {
            {"IT",  "Note Private"},
            {"EN",  "Note Private"}
        };

        Dictionary<string, string> _StrNotePubbliche = new Dictionary<string, string>
        {
            {"IT",  "Note Pubbliche"},
            {"EN",  "Note Pubbliche"}
        };

        Dictionary<string, string> _StrDataNascita = new Dictionary<string, string>
        {
            {"IT",  "Data di nascita"},
            {"EN",  "Data di nascita"}
        };

        Dictionary<string, string> _StrCellulare = new Dictionary<string, string>
        {
            {"IT",  "Cellulare"},
            {"EN",  "Cellulare"}
        };

        Dictionary<string, string> _StrOkInvioAvvisi = new Dictionary<string, string>
        {
            {"IT",  "Ricevi Avvisi"},
            {"EN",  "Ricevi Avvisi"}
        };



        Dictionary<string, string> _StrCercaContatto = new Dictionary<string, string>
        {
            {"IT",  "Cerca Contatto"},
            {"EN",  "Contact Filter"}
        };
        Dictionary<string, string> _StrNumeroContatti = new Dictionary<string, string>
        {
            {"IT",  "Trovati {0} clienti"},
            {"EN",  "Founded {0} customers"}
        };
        Dictionary<string, string> _ErrUsernameOrPasswordNotValid = new Dictionary<string, string>
        {
            {"IT",  "Username o password non validi"},
            {"EN",  "Username or passwoerd not valid"}
        };
        Dictionary<string, string> _StrPassword = new Dictionary<string, string>
        {
            {"IT",  "Password"},
            {"EN",  "Password"}
        };

        Dictionary<string, string> _StrUserName = new Dictionary<string, string>
        {
            {"IT",  "UserName"},
            {"EN",  "UserName"}
        };

        Dictionary<string, string> _StrAccedi = new Dictionary<string, string>
        {
            {"IT",  "Accedi"},
            {"EN",  "LogIn"}
        };





        public Traductions(Page curPage, INavigation navigation) : base(curPage, navigation)
        {
        }








        string defaultLang = "IT";

        string GetCurvalueLang(Dictionary<string, string> elemento)
        {
            if (elemento == null) return string.Empty;
            if (elemento.ContainsKey(App.CurLang)) return elemento[App.CurLang];
            if (elemento.ContainsKey(defaultLang)) return elemento[defaultLang];
            return "OOOPS";
        }



      


    }
}
