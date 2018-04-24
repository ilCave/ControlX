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

        public void OnEndRefresh()
        {
            ElencoContattiList.EndRefresh();
        }

    }
}
