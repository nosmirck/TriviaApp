using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TriviaApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
	{
		protected INavigationService NavigationService { get; private set; }
		protected IPageDialogService PageDialogService { get; private set; }
		protected IUserDialogs UserDialogs { get; private set; }

		private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
        {
            NavigationService = navigationService;
			PageDialogService = pageDialogService;
			UserDialogs = userDialogs;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
