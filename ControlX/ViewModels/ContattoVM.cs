using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlX.ViewModels
{
    public class ContattoVM: BaseViewModel
    {

        public bool IsInsert
        {
            get
            {
                if (Item == null) return true;
                return (Guid.Equals(Guid.Empty, Item.Objectid));
            }
        }

        ObservableCollection<Models.ChiaveValore> _Lingue;
        public ObservableCollection<Models.ChiaveValore> Lingue
        {
            get
            {
                if (_Lingue == null)
                {
                    _Lingue  = new ObservableCollection<Models.ChiaveValore>();
                    _Lingue.Add(new Models.ChiaveValore() { Chiave = "IT", Valore ="Italiano" });
                    _Lingue.Add(new Models.ChiaveValore() { Chiave = "DE", Valore ="Tedesco" });
                    _Lingue.Add(new Models.ChiaveValore() { Chiave = "EN", Valore ="Inglese" });
                }
                return _Lingue;
            }
            set
            {
                _Lingue = value;
                OnPropertyChanged();
            }

        }

        public ContattoVM(Page curPage, INavigation navigation, Models.Contatto contatto):base(curPage,navigation)
        {
            PropertyChanged += OnLocalPropertyChanged;
            Item = contatto;
            EditCommand = new Command(OnEditCommand);
            InsertCommand = new Command(OnInsertCommand);
            UpdateCommand = new Command(OnUpdateCommand);
            DeleteCommand = new Command(OnDeleteCommand);
           

        }

        private void OnLocalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "Item",  StringComparison.InvariantCultureIgnoreCase) && Item != null)
            {
                OnPropertyChanged("IsInsert");
                if (CurPage is Views.ContattoEditV) ((Views.ContattoEditV)CurPage).SelectComboLinguaByValue(Item.LanguageCode);
            }
        }

        private async void OnDeleteCommand(object obj)
        {
            try
            {
                
                var risposta = await CurPage.DisplayAlert(CurPage.Title, strConfermaEliminazioneContatto, strConferma, StrAnnulla);
                if (!risposta) return;
                IsRunning = true;
                var ritorno = await Orchestrator.Contatti.Delete(Item);
                if (ritorno.HasError)
                    throw new Exception(ritorno.Error);
                else
                {
                    // navigo nell'elenco dei contatti
                    CurPage.Navigation.PushAsync(new Views.ElencoContattiV());
                    return;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                await CurPage.DisplayAlert(CurPage.Title, Error, "Ok");
            }
            finally
            {
                IsRunning = false;
            }
        }

        private async void OnUpdateCommand(object obj)
        {
            try
            {
                IsRunning = true;
                var ritorno = await Orchestrator.Contatti.Update(Item, true);
                if (ritorno.HasError)
                    throw new Exception(ritorno.Error);
                else
                {
                    // navigo nell'elenco dei contatti
                    CurPage.Navigation.PushAsync(new Views.ElencoContattiV());
                    return;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                await CurPage.DisplayAlert(CurPage.Title, Error, "Ok");
            }
            finally
            {
                IsRunning = false;
            }

        }

        private async void OnInsertCommand(object obj)
        {
            try
            {
                IsRunning = true;
                var ritorno = await Orchestrator.Contatti.Insert(Item, true);
                if (ritorno.HasError)
                    throw new Exception(ritorno.Error);
                else
                {
                    // navigo nell'elenco dei contatti
                    CurPage.Navigation.PushAsync(new Views.ElencoContattiV());
                    return;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                await CurPage.DisplayAlert(CurPage.Title, Error, "Ok");
            }
            finally
            {
                IsRunning = false;
            }

        }

        private void OnEditCommand(object obj)
        {
            
            Navigation.PushAsync(new Views.ContattoEditV(Item));
        }

        public ICommand EditCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        Models.Contatto _Item;
        public Models.Contatto Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
                OnPropertyChanged();
            }
        }
    }
}
