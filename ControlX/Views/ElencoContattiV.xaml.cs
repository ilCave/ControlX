using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlX.Views
{
    public partial class ElencoContattiV : ContentPage
    {

        ViewModels.ElencoContattiVM viewModel = null;
        public ElencoContattiV()
        {
            InitializeComponent();
            viewModel = new ViewModels.ElencoContattiVM(this, this.Navigation);
            BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ElencoContattiList.SelectedItem = null;
        }

        public void OnEndRefresh()
        {
            ElencoContattiList.EndRefresh();
        }

    }
}
