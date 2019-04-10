using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PatientGuidance.App.Common;

namespace PatientGuidance.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isColo;
        private string _selectedDateValue = "Selected Date";
        private string _selectedTimeValue = "Selected time value";
        public string BurnLabel { get; set; } = "לידע";
        public DelegateCommand BurnFlow { get; set; }

        public string ColoLabel { get; set; } = "גסטרו";
        public DelegateCommand ColoFlow { get; set; }
    
        public ObservableCollection<object> SelectedDate { get; set; }
        public ObservableCollection<object> SelectedTime { get; set; }

        public string SelectedDateValue
        {
            get => _selectedDateValue;
            set => SetProperty(ref _selectedDateValue, value);
        }

        public string DateSelectionLabel { get; set; } = "לחץ לבחירת תאריך בדיקה";
        public string TimeSelectionLabel { get; set; } = "לחץ לבחירת שעת בדיקה";

        public string SelectedTimeValue
        {
            get => _selectedTimeValue;
            set => SetProperty(ref _selectedTimeValue, value);
        }

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
            Title = "בחירת טיפול";

            ColoFlow = new DelegateCommand(() => { IsColo = true; });
            Done = new DelegateCommand(async () => { await NavigationService.NavigateAsync("ColonoQuestionPage");});
        }

        public void DateSelectedApprove()
        {
            var a = $"{SelectedDate[0]} {SelectedDate[1]},{SelectedDate[2]}";
            var dateTime = DateTime.Parse(a);
            Settings.SelectedDate = dateTime;
            SelectedDateValue = $"התאריך שנבחר {dateTime:dd/MM/yyyy}";
        }

        public void TimeSelectionApprove()
        {
            Settings.SelectedHour = int.Parse(SelectedTime[0].ToString());
            Settings.SelectedMinutes = int.Parse(SelectedTime[1].ToString());
            SelectedTimeValue = $"זמן נבחר {Settings.SelectedHour}:{Settings.SelectedMinutes}";
        }
    }
}
