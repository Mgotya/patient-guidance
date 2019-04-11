using Prism.Commands;
using Prism.Navigation;

namespace PatientGuidance.App.ViewModels
{
	public class IntroGastroPageViewModel : ViewModelBase
	{
        public DelegateCommand Done { get; set; }

        public IntroGastroPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Done = new DelegateCommand(async  ()=> await NavigationService.NavigateAsync("StateContainerPage"));
        }
    }
}
