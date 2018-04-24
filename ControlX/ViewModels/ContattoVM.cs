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
        }

        private void OnEditCommand(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand EditCommand { get; set; }

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
