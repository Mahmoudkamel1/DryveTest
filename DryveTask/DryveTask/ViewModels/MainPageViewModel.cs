using System;
using System.Threading.Tasks;
using DryveTask.Bases;
using Prism.Navigation;

namespace DryveTask.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields

        #endregion

        #region Properties


        #endregion

        #region Commands


        #endregion

        #region ConstructorDestructor

        public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
        {

        }
        #endregion

        #region Methods
        #endregion

        #region Overrides
        public override async Task OnNavigation(INavigationParameters parameters, NavigationMode mode)
        {
            this.ShowLoading();

            this.HideLoading();
        }
        #endregion
    }
}
