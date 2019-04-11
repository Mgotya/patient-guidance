using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PatientGuidance.App.Common;
using PatientGuidance.App.Services;
using Prism.Commands;
using Prism.Navigation;

namespace PatientGuidance.App.ViewModels
{
	public class StateContainerPageViewModel : ViewModelBase
	{
        private readonly IInstructionCardsProvider _provider;
        public Action OnReady { get; set; } = () => { };
        public ObservableCollection<Card> Cards { get; set; }
        public DelegateCommand CompleateCommand { get; set; }

        public StateContainerPageViewModel(INavigationService navigationService, IInstructionCardsProvider provider) 
            : base(navigationService)
        {
            _provider = provider;
            Cards = new ObservableCollection<Card>();
            CompleateCommand = new DelegateCommand(async () =>
            {
                Settings.IsLogIn = false;
                await NavigationService.NavigateAsync("myapp:///NavigationPage/MainPage");
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IEnumerable<Card> enumerable = Settings.IsGastro ? await _provider.GetRelevantCardsAsync() : await _provider.GetBurnCardsAsync();
            foreach (var card in enumerable)
            {
                Cards.Add(card);
            }

            OnReady();
        }
    }
}
