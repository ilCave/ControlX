using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace ControlX.Views
{
    public partial class ContattoEditV : ContentPage
    {
        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            if (PickerLingua.SelectedIndex != -1)
            {
                var valore = viewModel.Lingue[PickerLingua.SelectedIndex].Chiave;
                viewModel.Item.LanguageCode = valore;
            }
           
        }


        public int IndexOfKey(ObservableCollection<Models.ChiaveValore> dictionary, string key)
        {

            int index = -1;
            foreach (var k in dictionary)
            {
                index++;
                if (string.Equals(k.Chiave, key, StringComparison.InvariantCultureIgnoreCase)) return index;
            }

            return -1;
        }

        public void SelectComboLinguaByValue(string languageCode)
        {
            if (viewModel == null) return;
            if (string.IsNullOrWhiteSpace(languageCode))
                PickerLingua.SelectedIndex = -1;
            else
            {
                var indice = IndexOfKey(viewModel.Lingue, languageCode);
                PickerLingua.SelectedIndex = indice;
            }
        }

        ViewModels.ContattoVM viewModel;

		protected override void OnAppearing()
		{
            base.OnAppearing();
            if (viewModel.Item != null) SelectComboLinguaByValue(viewModel.Item.LanguageCode);
		}

		public ContattoEditV()
        {
            InitializeComponent();
            viewModel = new ViewModels.ContattoVM(this, Navigation, new Models.Contatto());
            BindingContext = viewModel;
        }

        public ContattoEditV(Models.Contatto contatto)
        {
            InitializeComponent();
            viewModel = new ViewModels.ContattoVM(this, Navigation, contatto);
            BindingContext = viewModel;

        }
    }
}
