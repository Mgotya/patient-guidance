using Xamarin.Forms;

namespace PatientGuidance.App.Views
{
    public partial class StateContainerPage : ContentPage
    {
        public StateContainerPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
