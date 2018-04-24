using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlX.Interfaces;
using Xamarin.Forms;

namespace ControlX
{
    public class BaseViewModel : Resources.Traductions
    {
        public BaseViewModel(Page curPage, INavigation navigation) : base(curPage, navigation)
        {
        }

        public Interfaces.IControlXOrchestrator Orchestrator => DependencyService.Get<Interfaces.IControlXOrchestrator>() ?? new Services.ControlXOrchestrator();
    }
}
