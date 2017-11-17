using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using TriviaApp.Models;
using Xamarin.Forms;

namespace TriviaApp.ViewModels
{
	public class QuestionItemViewModel : BindableBase
	{
		private Question _question;
		private Answer _selectedAnswer;
		private ObservableCollection<Answer> _answers;
		private bool _isAnswerSelected;

		public Question Question
		{
			get { return _question; }
			set { SetProperty(ref _question, value); }
		}
		public ObservableCollection<Answer> Answers
		{
			get { return _answers; }
			set { SetProperty(ref _answers, value); }
		}
		public Answer SelectedAnswer
		{

			get { return null; }
			set
			{
				if (value != null)
				{
					if (!IsAnswerSelected)
					{
						IsAnswerSelected = true;
						_selectedAnswer = value;
						_selectedAnswer.IsSelected = true;
						Answers[Answers.IndexOf(_selectedAnswer)] = _selectedAnswer;
					}
					RaisePropertyChanged();
				}
			}
		}
		public Answer GetSelectedAnswer()
		{
			return _selectedAnswer;
		}

		public bool IsAnswerSelected
		{
			get { return _isAnswerSelected; }
			set { SetProperty(ref _isAnswerSelected, value); }
		}

		public QuestionItemViewModel(Question question)
		{
			if (question.Type == Question.QuestionType.Multiple)
			{
				Answers = new ObservableCollection<Answer>();
				foreach (string answerText in question.IncorrectAnswers)
				{
					Answers.Add(new Answer() { AnswerText = answerText, IsCorrect = false });
				}
				//Shuffle the answers
				Random rng = new Random();
				Answers.OrderBy(q => rng.Next());

				var rndIndex = rng.Next(Answers.Count);
				Answers.Insert(rndIndex, new Answer() { AnswerText = question.CorrectAnswer, IsCorrect = true });
			}
			else
			{
				Answers = new ObservableCollection<Answer>();
				var isTrueCorrect = question.CorrectAnswer == "True";
				Answers.Add(new Answer() { AnswerText = "True", IsCorrect = isTrueCorrect });
				Answers.Add(new Answer() { AnswerText = "False", IsCorrect = !isTrueCorrect });
			}
			Question = question;
		}

		public class Answer
		{
			public string AnswerText { get; set; }
			public bool IsCorrect { get; set; }
			public bool IsSelected { get; set; }
		}
	}
}
