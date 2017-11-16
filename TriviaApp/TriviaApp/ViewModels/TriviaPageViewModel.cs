using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TriviaApp.Models;

namespace TriviaApp.ViewModels
{
	public class TriviaPageViewModel : ViewModelBase
	{
		private ObservableCollection<Question> _questions;
		public ObservableCollection<Question> Questions
		{
			get { return _questions; }
			set { SetProperty(ref _questions, value); }
		}

		private string _content;
		public string Content
		{
			get { return _content; }
			set { SetProperty(ref _content, value); }
		}

		public TriviaPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
			: base(navigationService, pageDialogService, userDialogs)
		{

		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);

			if (parameters.ContainsKey("Questions"))
			{
				var questions = parameters.GetValue<List<Question>>("Questions");
				Questions = new ObservableCollection<Question>(questions);

				Content = Questions.ToString();
			}
		}
	}
}
