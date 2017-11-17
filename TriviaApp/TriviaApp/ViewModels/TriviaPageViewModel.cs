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
using Xamarin.Forms;

namespace TriviaApp.ViewModels
{
	public class TriviaPageViewModel : ViewModelBase
	{
		private List<QuestionItemViewModel> Questions;
		private QuestionItemViewModel _currentQuestion;
		private string _questionCounter;
		private int _currentQuestionIndex;
		private bool _isLastQuestion;

		public string QuestionCounter
		{
			get { return _questionCounter; }
			set { SetProperty(ref _questionCounter, value); }
		}
		public QuestionItemViewModel CurrentQuestion
		{
			get { return _currentQuestion; }
			set
			{
				NextQuestionCommand?.ChangeCanExecute();
				PrevQuestionCommand?.ChangeCanExecute();
				SetProperty(ref _currentQuestion, value);
			}
		}
		public int CurrentQuestionIndex
		{
			get { return _currentQuestionIndex; }
			set
			{
				_currentQuestionIndex = value;
				QuestionCounter = string.Format("Question: {0}/{1}", _currentQuestionIndex + 1, Questions?.Count);
			}
		}
		public bool IsLastQuestion
		{
			get { return _isLastQuestion; }
			set { SetProperty(ref _isLastQuestion, value); }
		}

		public Command NextQuestionCommand { get; set; }
		public Command PrevQuestionCommand { get; set; }
		public Command ShowResultsCommand { get; set; }

		public TriviaPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IUserDialogs userDialogs)
			: base(navigationService, pageDialogService, userDialogs)
		{
			Questions = new List<QuestionItemViewModel>();
			CurrentQuestion = new QuestionItemViewModel(new Question());
			NextQuestionCommand = new Command(NextQuestion, CanExecuteNext);
			PrevQuestionCommand = new Command(PrevQuestion, CanExecutePrev);
			ShowResultsCommand = new Command(ShowResults);
		}

		private void ShowResults(object obj)
		{
			int score = 0;
			foreach (QuestionItemViewModel questionItem in Questions)
			{
				if (questionItem.GetSelectedAnswer() != null && questionItem.GetSelectedAnswer().IsCorrect)
				{
					score++;
				}
			}
			NavigationParameters parameters = new NavigationParameters()
			{
				{"Score", score },
				{"Count", Questions.Count}
			};
			NavigationService.GoBackAsync(parameters);
		}

		private bool CanExecutePrev(object arg)
		{
			return _currentQuestionIndex > 0;
		}

		private void PrevQuestion(object obj)
		{
			if (_currentQuestionIndex > 0)
			{
				CurrentQuestionIndex = CurrentQuestionIndex - 1;
				CurrentQuestion = Questions[_currentQuestionIndex];
				IsLastQuestion = CurrentQuestionIndex == Questions.Count - 1;
			}
		}

		private bool CanExecuteNext(object arg)
		{
			return _currentQuestionIndex < Questions.Count - 1;
		}

		private void NextQuestion(object obj)
		{
			if (_currentQuestionIndex < Questions.Count - 1)
			{
				CurrentQuestionIndex = CurrentQuestionIndex + 1;
				CurrentQuestion = Questions[_currentQuestionIndex];
				IsLastQuestion = CurrentQuestionIndex == Questions.Count - 1;
			}
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);

			if (parameters.ContainsKey("Questions"))
			{
				var questions = parameters.GetValue<List<Question>>("Questions");

				foreach (Question question in questions)
				{
					Questions.Add(new QuestionItemViewModel(question));
				}
				CurrentQuestion = Questions.First();
				CurrentQuestionIndex = 0;
			}
		}
	}
}
