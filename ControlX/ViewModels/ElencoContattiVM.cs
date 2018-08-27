using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlX.ViewModels
{
    public class ElencoContattiVM : BaseViewModel    
    {

        public string NumeroElementi
        {
            get
            {
                return String.Format(StrNumeroContatti, Items == null ? 0 : Items.Count);
            }
        }

        string filtro = String.Empty;
        public string Filtro
        {
            get
            {
                return filtro;
            }
            set
            {
                filtro = value;
                OnPropertyChanged();
            }
        }

        public ElencoContattiVM(Page curPage, INavigation navigation):base(curPage, navigation)
        {
            ForceRefreshCommand = new Command(OnForceRefreshCommand);
            PropertyChanged += OnLocalPropertyChanged;
            AddCommand = new Command(OnAddCommand);

        }

        private void OnAddCommand(object obj)
        {
            Navigation.PushAsync(new Views.ContattoEditV());
        }

        private void OnLocalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "Filtro"))
            {
                OnPropertyChanged("Items");
            }
            if (string.Equals(e.PropertyName, "Items"))
            {
                OnPropertyChanged("NumeroElementi");
                ((Views.ElencoContattiV)CurPage).OnEndRefresh();
            }
        }

        private void OnForceRefreshCommand(object obj)
        {
            ForceRefresh = true;
            OnPropertyChanged("Items");
        }

        public bool ForceRefresh=false;
        public ICommand ForceRefreshCommand { get; set; }
        public ICommand AddCommand { get; set; }


        public Models.Contatto SelectedItem
        {
            set
            {
                if (value != null)
                {
                    Navigation.PushAsync(new Views.ContattoV(value));
                }
            }
        }


        ObservableCollection<Models.Contatto> _Items = null;
        public ObservableCollection<Models.Contatto> Items
        {
            get
            {
                if ((_Items == null && !contattiLoading) || ForceRefresh)
                    LoadContatti(ForceRefresh);
                if (!string.IsNullOrWhiteSpace(filtro) && _Items != null)

                    return new ObservableCollection<Models.Contatto>(_Items.Where(x => x.NomeECognome.Contains(filtro.ToUpper())));
                
                else
                return _Items;
            }

            set
            {
                _Items = value;
                OnPropertyChanged();
            }
        }


        bool contattiLoading = false;
        private async void LoadContatti(bool forceRefresh)
        {
            if (!contattiLoading)
            {
                IsRunning = true;
                contattiLoading = true;
                try
                {
                    var contatti = await Orchestrator.Contatti.GetItemsAsync(forceRefresh);
                    contatti = contatti.OrderBy(x => x.Nome).ToList();
                    Items = new ObservableCollection<Models.Contatto>(contatti);
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
                finally
                {
                    IsRunning = false;
                    contattiLoading = false;
                }

            }
        }
    }
}

