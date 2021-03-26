using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace DryveTask.Bases
{
    public abstract class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        #region Fields
        string _title;
        bool _isBusy;
        int _rtl;
        private bool _isConnected = true;
        INavigationService NavigationService;
        public bool IsNotConnected
        {
            get => _isConnected;
            set => SetProperty(ref this._isConnected, value);
        }
        string _busyMessage;
        INavigationParameters _navParams;
        #endregion
        #region Properties
        public INavigationParameters NavParams
        {
            get => this._navParams;
            set => this.SetProperty(ref this._navParams, value);
        }
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }
        public bool IsBusy
        {
            get => this._isBusy;
            set => this.SetProperty(ref this._isBusy, value);
        }
        public string BusyMessage
        {
            get => this._busyMessage;
            set => this.SetProperty(ref this._busyMessage, value);
        }
        public int Rtl
        {
            get => this._rtl;
            set => this.SetProperty(ref this._rtl, value);
        }
        #endregion
        #region ConstructorDestructor
        public BaseViewModel(INavigationService navigationService)
        {
            Console.WriteLine("--------------------------------------------------------------------- " + this.GetType().Name);
            this.NavigationService = navigationService;
        }
        ~BaseViewModel()
        {
        }
        #endregion
        #region Methods
        void Connectivity_ConnectivityChanged(object sender, Xamarin.Essentials.ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet;
        }
        public abstract Task OnNavigation(INavigationParameters parameters, NavigationMode navigationMode);
        public virtual Task OnNavigationFromPush(INavigationParameters parameters) => Task.FromResult(0);
        public virtual void OnNavigatingTo(NavigationParameters parameters)
        { }
        public void HideLoading()
        {
            this.IsBusy = false;
            this.BusyMessage = null;
        }
        public void ShowLoading(string message = null)
        {
            this.IsBusy = true;
            this.BusyMessage = message;
        }
        #endregion
        #region IDestructible Members
        public virtual void Destroy()
        {
        }
        #endregion
        #region INavigatedAware Members
        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                bool isNavigationFromPush = parameters.GetValue<bool>("NavigationFromPush");
                if (isNavigationFromPush)
                {
                    await this.OnNavigationFromPush(parameters);
                }
                else
                {
                    await this.OnNavigation(parameters, parameters.GetNavigationMode());
                }
            }
            catch (Exception ex)
            {
                this.HideLoading();
            }
        }
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        { }
        #endregion
    }
}
