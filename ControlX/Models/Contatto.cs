using System;
using System.ComponentModel;
using SQLite;

namespace ControlX.Models
{
    public class Contatto: DocsMarshal.MVVM.Models.BaseModelEntity
    {
        public Contatto()
        {
            PropertyChanged += MyLocalPropertyChanged;
        }

        private void MyLocalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if  ((string.Equals("Nome", e.PropertyName, StringComparison.InvariantCultureIgnoreCase)) ||
                (string.Equals("Cognome", e.PropertyName, StringComparison.InvariantCultureIgnoreCase)))
            {
                OnPropertyChanged("NomeECognome");
            }
        }

        string nome;
        public string Nome 
        { 
            get { return nome; }

            set 
            {
                if (!string.Equals(nome, value, StringComparison.CurrentCulture))
                {
                    nome = value;
                    OnPropertyChanged();
                }

            }
        }
       
        string cognome;
        public string Cognome
        {
            get { return cognome; }

            set
            {
                if (!string.Equals(cognome, value, StringComparison.CurrentCulture))
                {
                    cognome = value;
                    OnPropertyChanged();
                }

            }
        }


        public string QrCodeRegistrazione { get; set; }
        public DateTime? QrCodeScadenza { get; set; }
        public string Sesso { get; set;}
        public string RefIdSaloni { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool OkPubb { get; set; }
        public bool OkAlertOffTaglio { get; set; }
        public string Telefono { get; set; }
        public string UserName { get; set; }
        public string NotePubbliche { get; set; }
        public string NotePrivate { get; set; }
        public DateTime? DataNascita { get; set; }
        public string Cellulare { get; set; }
        public bool OkInvioAvvisi { get; set; }
        public DateTime DataNascitaV 
        {
            get
            {
                if (DataNascita.HasValue)
                    return DataNascita.Value;
                else
                    return DateTime.Today;
            }
        }

        [Ignore]
        public string NomeECognome
        {
            get
            {
                string ritorno = Nome + " " + Cognome;
                ritorno = ritorno.Trim();
                return ritorno.ToUpper();
            }
        }

        [Ignore]
        public string Telefoni
        {
            get
            {
                string ritorno = string.Empty;
                if (!string.IsNullOrWhiteSpace(Cellulare)) ritorno = Cellulare;
                if (!string.IsNullOrWhiteSpace(Telefono)) ritorno += " " + Telefono;
                return ritorno.Trim();
            }
        }

    }
}
