using DryIoc;
using DryveTask.Helpers;
using DryveTask.services.Interfaces;
using DryveTask.ViewModels;
using DryveTask.Views;
using FlickrList.services.implementations;
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
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Pages
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation"); // required by PRISM
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>(Routes.ListPageStringKey);

            // Services

            containerRegistry.Register<IFlickrServices, FlickrServices>();

        }

        protected override async void OnInitialized()
        {
            this.InitializeComponent();

            await this.NavigationService.NavigateAsync($"{Routes.ListPageStringKey}");
        }

    }
}
