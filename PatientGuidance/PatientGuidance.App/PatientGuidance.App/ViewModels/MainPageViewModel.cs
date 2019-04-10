using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PatientGuidance.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isColo;
        public string BurnLabel { get; set; } = "לידע";
        public DelegateCommand BurnFlow { get; set; }

        public string ColoLabel { get; set; } = "גסטרו";
        public DelegateCommand ColoFlow { get; set; }
    
        public ObservableCollection<object> SelectedTime { get; set; }
        public ObservableCollection<object> StartDate { get; set; }

        public bool IsColo
        {
            get => _isColo;
            set => SetProperty(ref _isColo, value);
        }

        public bool IsBurn { get; set; }

        public string DoneLabel { get; set; } = "המשך";
        public DelegateCommand Done { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";


            ColoFlow = new DelegateCommand(() => { IsColo = true; });
            Done = new DelegateCommand(async () => { await NavigationService.NavigateAsync("ColonoQuestionPage");});
        }

        public void DateSelectedApprove()
        {

        }

        public void TimeSelectionApprove()
        {

        }
    }
}
