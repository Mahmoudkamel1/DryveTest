using DryIoc;
using DryveTask.Helpers;
using DryveTask.ViewModels;
using DryveTask.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Xamarin.Essentials;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;
using Page = Xamarin.Forms.Page;

namespace DryveTask
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Pages

            containerRegistry.RegisterForNavigation<MainPage>(Routes.MainPageStringKey);

            // Register ViewModels
            ViewModelLocationProvider.Register<MainPage>(() => Container.Resolve<MainPageViewModel>());

            // Behaviours

        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            this.NavigationService.NavigateAsync(string.Format("{0}", Routes.MainPageStringKey));
        }

    }
}
