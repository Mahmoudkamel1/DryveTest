using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DryveTask.Bases;
using DryveTask.Helpers;
using DryveTask.Models;
using DryveTask.services.Interfaces;
using Prism.Navigation;

namespace DryveTask.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields
        private List<Photo> _pictures;
        readonly IFlickrServices _flickerServices;
        #endregion

        #region Properties

        public List<Photo> Pictures
        {
            get => _pictures;
            set => SetProperty(ref this._pictures, value);
        }

        public async Task GetPictures()
        {
            
            this.Pictures = await _flickerServices.GetPictures();
        }

        #endregion

        #region Commands


        #endregion

        #region ConstructorDestructor

        public MainPageViewModel(INavigationService navigationService, IFlickrServices flickerServices)
        : base(navigationService)
        {
            _flickerServices = flickerServices;
        }
        #endregion

        #region Methods
        #endregion

        #region Overrides
        public override async Task OnNavigation(INavigationParameters parameters, NavigationMode mode)
        {
            await GetPictures();
        }
        #endregion
    }
}
