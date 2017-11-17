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

		private bool _isResultsShowing;
		private int _score;
		private int _count;
		private string _playGameButtonText;

		public bool IsResultsShowing
		{
			get { return _isResultsShowing; }
			set { SetProperty(ref _isResultsShowing, value); }
		}
		public int Score
		{
			get { return _score; }
			set { SetProperty(ref _score, value); }
		}
		public int Count
		{
			get { return _count; }
			set { SetProperty(ref _count, value); }
		}
		public string PlayGameButtonText
		{
			get { return _playGameButtonText; }
			set { SetProperty(ref _playGameButtonText, value); }
		}

		public Command PlayNewGameCommand { get; set; }
		public MainPageViewModel(ITriviaService triviaService, INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
			: base(navigationService, pageDialogService, userDialogs)
		{
			Title = "Main Page";
			_triviaService = triviaService;
			IsResultsShowing = false;
			PlayGameButtonText = "Play!";
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
					if (questions == null)
					{
						await PageDialogService.DisplayAlertAsync("Sorry!", "There are no questions available, please try again later.", "OK");
					}
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
		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			if (parameters.ContainsKey("Score"))
			{
				Score = parameters.GetValue<int>("Score");
				IsResultsShowing = true;
				PlayGameButtonText = "Play Again!";
			}
			if (parameters.ContainsKey("Score"))
			{
				Count = parameters.GetValue<int>("Count");
			}
		}
	}
}
