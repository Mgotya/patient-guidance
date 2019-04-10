using System.Collections.ObjectModel;
using Syncfusion.SfPicker.XForms;

namespace PatientGuidance.App.Controls
{
    public class CustomTimePicker : SfPicker
    {

        public ObservableCollection<object> Time { get; set; }
        public ObservableCollection<object> Minute;
        public ObservableCollection<object> Hour;

        public ObservableCollection<string> Headers { get; set; }

        public CustomTimePicker()
        {
            Time = new ObservableCollection<object>();
            Hour = new ObservableCollection<object>();
            Minute = new ObservableCollection<object>();

            PopulateTimeCollection();

            this.ItemsSource = Time;
            Headers = new ObservableCollection<string> { "שעות", "דקות" };
            HeaderText = "בחירת זמן";
            this.ColumnHeaderText = Headers;

            ShowFooter = true;
            ShowHeader = true;
            ShowColumnHeader = true;
        }

        private void PopulateTimeCollection()
        {
            for (var i = 0; i <= 23; i++)
                Hour.Add(i.ToString());

            for (int j = 0; j < 60; j++)
            {
                if (j < 10)
                    Minute.Add("0" + j);
                else
                    Minute.Add(j.ToString());
            }

            Time.Add(Hour);
            Time.Add(Minute);
        }
    }
}
