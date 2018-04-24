using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlX.Views
{
    public partial class WelcomeV : ContentPage
    {

        ViewModels.WelcomeVM viewModel = null;

        public WelcomeV()
        {
            InitializeComponent();
            viewModel = new ViewModels.WelcomeVM(this, Navigation);
            BindingContext = viewModel;
        }
    }
}
