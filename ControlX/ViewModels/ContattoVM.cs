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

        private void OnInsertCommand(object obj)
        {
            throw new NotImplementedException();
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
