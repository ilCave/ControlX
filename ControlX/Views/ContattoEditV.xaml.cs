using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlX.Views
{
    public partial class ContattoEditV : ContentPage
    {

        ViewModels.ContattoVM viewModel;


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
