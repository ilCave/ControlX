using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlX.ViewModels
{
    public class ContattoVM: BaseViewModel
    {
        public ContattoVM(Page curPage, INavigation navigation, Models.Contatto contatto):base(curPage,navigation)
        {
            Item = contatto;
            EditCommand = new Command(OnEditCommand);
            InsertCommand = new Command(OnInsertCommand);
            UpdateCommand = new Command(OnUpdateCommand);
            DeleteCommand = new Command(OnDeleteCommand);
        }

        private void OnDeleteCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnUpdateCommand(object obj)
        {
            throw new NotImplementedException();
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
                CurPage.DisplayAlert(CurPage.Title, Error, "Ok");
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
