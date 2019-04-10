using PatientGuidance.App.Services;
using Prism;
using Prism.Ioc;
using PatientGuidance.App.ViewModels;
using PatientGuidance.App.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PatientGuidance.App
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("NTczMjhAMzEzNjJlMzQyZTMwSWY0OVZ4V2lIMjFsdklKVzhaTmZrVURpNjdCSkVVelUxcHlaZGtZTzVCbz0=");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<IQuestionProvider, TempQuestionProvider>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ColonoQuestionPage, ColonoQuestionPageViewModel>();
            containerRegistry.RegisterForNavigation<StateContainerPage, StateContainerPageViewModel>();
        }
    }
}
