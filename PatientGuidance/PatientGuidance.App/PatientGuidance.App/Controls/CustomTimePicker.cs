using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Syncfusion.SfPicker.XForms;

namespace PatientGuidance.App.Controls
{
    public class CustomTimePicker : SfPicker
    {

        public ObservableCollection<object> Time { get; set; }
        public ObservableCollection<object> Minute;
        public ObservableCollection<object> Hour;
        public ObservableCollection<object> Format;

        public ObservableCollection<string> Headers { get; set; }

        public CustomTimePicker()
        {
            Time = new ObservableCollection<object>();
            Hour = new ObservableCollection<object>();
            Minute = new ObservableCollection<object>();
            Format = new ObservableCollection<object>();

            PopulateTimeCollection();

            this.ItemsSource = Time;
            Headers = new ObservableCollection<string> { "Hour", "Minute", "Format" };
            HeaderText = "TIME PICKER";
            this.ColumnHeaderText = Headers;

            ShowFooter = true;
            ShowHeader = true;
            ShowColumnHeader = true;
        }

        private void PopulateTimeCollection()
        {

            for (int i = 1; i <= 12; i++)
            {
                Hour.Add(i.ToString());
            }

            for (int j = 0; j < 60; j++)
            {

                if (j < 10)
                {
                    Minute.Add("0" + j);
                }
                else
                    Minute.Add(j.ToString());
            }

            Format.Add("AM");
            Format.Add("PM");
            Time.Add(Hour);
            Time.Add(Minute);
            Time.Add(Format);
        }
    }
}
