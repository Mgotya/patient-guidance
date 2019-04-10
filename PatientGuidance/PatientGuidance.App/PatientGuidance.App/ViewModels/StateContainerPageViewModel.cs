using PatientGuidance.App.Services;
using Prism.Navigation;

namespace PatientGuidance.App.ViewModels
{
	public class StateContainerPageViewModel : ViewModelBase
	{
        private readonly IInstructionCardsProvider _provider;

        public StateContainerPageViewModel(INavigationService navigationService, IInstructionCardsProvider provider) 
            : base(navigationService)
        {
            _provider = provider;
        }
    }
}
