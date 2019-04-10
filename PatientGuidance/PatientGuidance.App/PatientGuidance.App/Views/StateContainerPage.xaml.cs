using PatientGuidance.App.ViewModels;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;

namespace PatientGuidance.App.Views
{
    public partial class StateContainerPage : ContentPage
    {
        public StateContainerPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (BindingContext is StateContainerPageViewModel ctx)
            {
                ctx.OnReady = Loaded;
            }
        }

        private void Loaded()
        {
            var tabView = new SfTabView();
            Grid allContactsGrid = new Grid { BackgroundColor = Color.Red };
            Grid favoritesGrid = new Grid { BackgroundColor = Color.Green };
            Grid contactsGrid = new Grid { BackgroundColor = Color.Blue };
            var tabItems = new TabItemCollection
            {
                new SfTabItem()
                {
                    Title = "Calls",
                    Content = allContactsGrid
                },
                new SfTabItem()
                {
                    Title = "Favorites",
                    Content = favoritesGrid
                },
                new SfTabItem()
                {
                    Title = "Contacts",
                    Content = contactsGrid
                }
            };
            tabView.Items = tabItems;
            this.Content = tabView;
        }
    }
}
