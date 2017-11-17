using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TriviaApp.Models
{
	public class Question
	{
		private string correctAnswer;
		private List<string> incorrectAnswers;
		private string questionText;

		public static class QuestionType
		{
			public static readonly string Multiple = "multiple";
			public static readonly string TrueOrFalse = "boolean";
		}

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("correct_answer")]
		public string CorrectAnswer
		{
			get
			{
				return correctAnswer;
			}

			set
			{
				correctAnswer = System.Net.WebUtility.HtmlDecode(value);
			}
		}

		[JsonProperty("difficulty")]
		public string Difficulty { get; set; }

		[JsonProperty("incorrect_answers")]
		public List<string> IncorrectAnswers
		{
			get
			{
				return incorrectAnswers;
			}

			set
			{
				incorrectAnswers = value.Select(incorrectAnswer => System.Net.WebUtility.HtmlDecode(incorrectAnswer)).ToList();
			}
		}


		[JsonProperty("question")]
		public string QuestionText
		{
			get
			{
				return questionText;
			}

			set
			{
				questionText = System.Net.WebUtility.HtmlDecode(value);
			}
		}

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
