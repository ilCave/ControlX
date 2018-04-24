using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlX.Views
{
    public partial class ContattoV : ContentPage
    {
        ViewModels.ContattoVM viewModel;

        public ContattoV(Models.Contatto contatto)
        {
            InitializeComponent();
            viewModel = new ViewModels.ContattoVM(this, Navigation, contatto);
            BindingContext = viewModel;
        }

        void TelClicked(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("tel:" + viewModel.Item.Telefono));
        }

        void CelClicked(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("tel:" + viewModel.Item.Cellulare));
        }
    }
}
