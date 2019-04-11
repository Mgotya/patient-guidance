using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using PatientGuidance.App.Common;
using Color = Xamarin.Forms.Color;

namespace PatientGuidance.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region members
        private readonly Color _notActive = Color.DimGray;
        private readonly Color _active = Color.CornflowerBlue;
        private readonly Color _disabled = Color.DarkSlateGray;
        private Color _burnColor;
        private Color _coloColor;
        private bool _isColo;
        private string _selectedDateValue = "תאריך לא נבחר";
        private string _selectedTimeValue = "זמן לא נבחר";
        private bool _isDone;
        #endregion

        #region properties
        public string BurnLabel { get; set; } = "לידע";
        public string ColoLabel { get; set; } = "גסטרו";
        public string DateSelectionLabel { get; set; } = "לחץ לבחירת תאריך בדיקה";
        public string TimeSelectionLabel { get; set; } = "לחץ לבחירת שעת בדיקה";
        public string DoneLabel { get; set; } = "המשך";
        public string SelectedDateValue
        {
            get => _selectedDateValue;
            set => SetProperty(ref _selectedDateValue, value);
        }
        public string SelectedTimeValue
        {
            get => _selectedTimeValue;
            set => SetProperty(ref _selectedTimeValue, value);
        }

        public DelegateCommand BurnFlow { get; set; }
        public DelegateCommand ColoFlow { get; set; }
        public DelegateCommand Done { get; set; }

        public ObservableCollection<object> SelectedDate { get; set; }
        public ObservableCollection<object> SelectedTime { get; set; }

        public bool IsColo
        {
            get => _isColo;
            set => SetProperty(ref _isColo, value);
        }
        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value; 
                Done.RaiseCanExecuteChanged();
            }
        }
        public Color BurnColor
        {
            get => _burnColor;
            set => SetProperty(ref _burnColor, value);
        }
        public Color ColoColor
        {
            get => _coloColor;
            set => SetProperty(ref _coloColor, value);
        }

        public bool IsTimeSelected { get; set; }
        public bool IsDateSelected { get; set; }
        #endregion

        #region constructor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ColoFlow = new DelegateCommand(OnColoFlowSelection);
            BurnFlow = new DelegateCommand(OnBurnFlowSelection);
            Done = new DelegateCommand(OnSelectionCompleated,CanCompleate);

            BurnColor = ColoColor = _notActive;
            IsDone = false;
        }

        private bool CanCompleate()
            => IsDone;

        private async void OnSelectionCompleated()
        {
            Settings.IsGastro = IsColo;

            if(IsColo)
                await NavigationService.NavigateAsync("ColonoQuestionPage");
            else
                await NavigationService.NavigateAsync("StateContainerPage");
        }

        #endregion

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (Settings.IsLogIn)
                await NavigationService.NavigateAsync("StateContainerPage");

        }

        public void DateSelectedApprove()
        {
            var a = $"{SelectedDate[0]} {SelectedDate[1]},{SelectedDate[2]}";
            var dateTime = DateTime.Parse(a);
            Settings.SelectedDate = dateTime;
            SelectedDateValue = $"התאריך שנבחר {dateTime:dd/MM/yyyy}";
            IsDateSelected = true;
            CheckIfColoDone();
        }

        public void TimeSelectionApprove()
        {
            Settings.SelectedHour = int.Parse(SelectedTime[0].ToString());
            Settings.SelectedMinutes = int.Parse(SelectedTime[1].ToString());
            SelectedTimeValue = $"זמן נבחר {Settings.SelectedHour}:{Settings.SelectedMinutes}";
            IsTimeSelected = true;
            CheckIfColoDone();
        }

        #region private methods
        private void CheckIfColoDone()
        {
            if (IsColo && IsTimeSelected && IsDateSelected)
            {
                IsDone = true;
            }
            else
            {
                IsDone = false;
            }
        }

        private void OnColoFlowSelection()
        {
            ColoColor = _active;
            BurnColor = _disabled;
            IsColo = true;
            CheckIfColoDone();
        }

        private void OnBurnFlowSelection()
        {
            ColoColor = _disabled;
            BurnColor = _active;
            IsColo = false;
            IsDone = true;
        } 
        #endregion
    }
}
