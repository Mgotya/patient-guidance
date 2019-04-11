using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace PatientGuidance.App.ViewModels
{
	public class VideoPageViewModel : ViewModelBase
	{
        public VideoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string Url { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("url"))
            {
                Url = parameters["url"].ToString();
            }
        }
    }
}
