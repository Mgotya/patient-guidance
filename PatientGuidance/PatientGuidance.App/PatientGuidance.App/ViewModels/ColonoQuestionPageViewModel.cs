using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PatientGuidance.App.ViewModels
{
	public class ColonoQuestionPageViewModel : ViewModelBase
	{
        public ColonoQuestionPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }
    }
}
