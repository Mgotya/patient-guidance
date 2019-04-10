using PatientGuidance.App.Common;
using PatientGuidance.App.ViewModels;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;

namespace PatientGuidance.App.Views
{
    public partial class StateContainerPage : ContentPage
    {

        private StateContainerPageViewModel _ctx;

        public StateContainerPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (BindingContext is StateContainerPageViewModel ctx)
            {
                _ctx = ctx;
                ctx.OnReady = Loaded;
            }
        }

        private void Loaded()
        {
            var tabView = new SfTabView();
            var tabItems = new TabItemCollection();
            foreach (var c in _ctx.Cards)
            {
                switch (c.Type)
                {
                    case CardType.Default:
                        Grid defaultGrid = new Grid();
                        defaultGrid.RowDefinitions = new RowDefinitionCollection
                        {
                            new RowDefinition
                            {
                                Height = GridLength.Star
                            },
                            new RowDefinition
                            {
                                Height = GridLength.Auto
                            }
                        };
                        
                        tabItems.Add(new SfTabItem
                        {
                            Title = c.Title,
                            Content = defaultGrid
                        });
                        break;
                }
            }
            tabView.Items = tabItems;
            this.Content = tabView;
            
        }
    }
}
