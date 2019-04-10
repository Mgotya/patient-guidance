using System;
using PatientGuidance.App.ViewModels;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.SfPicker.XForms.SelectionChangedEventArgs;

namespace PatientGuidance.App.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            date.IsOpen = !date.IsOpen;
        }

        private void Time_Clicked(object sender, EventArgs e)
        {
            time.IsOpen = !time.IsOpen;
        }

        private void ApproveDateEvent(object sender, SelectionChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel context)
            {
                context.DateSelectedApprove();
            }
        }

        private void ApproveTime(object sender, SelectionChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel context)
            {
                context.TimeSelectionApprove();
            }
        }
    }
}