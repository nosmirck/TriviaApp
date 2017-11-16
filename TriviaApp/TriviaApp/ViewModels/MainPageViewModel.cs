using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Business;
using Xamarin.Forms;

namespace TriviaApp.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private ITriviaService _triviaService { get; set; }

		public Command PlayNewGameCommand { get; set; }
		public MainPageViewModel(ITriviaService triviaService, INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
			: base(navigationService, pageDialogService, userDialogs)
		{
			Title = "Main Page";
			_triviaService = triviaService;

			PlayNewGameCommand = new Command(async () => await PlayNewGame());
		}

		private async Task PlayNewGame()
		{
			try
			{
				NavigationParameters parameters;
				using (UserDialogs.Loading())
				{
					var questions = await _triviaService.GetQuestions();
					parameters = new NavigationParameters()
					{
						{"Questions", questions }
					};
				}

				await NavigationService.NavigateAsync("TriviaPage", parameters);
			}
			catch (Exception ex)
			{
				await PageDialogService.DisplayAlertAsync("Error", ex.Message, "OK");
			}
		}
	}
}
