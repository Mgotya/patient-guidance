using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientGuidance.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand Excute { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            Excute = new DelegateCommand(() =>
            {

            });
        }
    }
}
