using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TriviaApp.Models
{
	public class Question
	{
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("correct_answer")]
		public string CorrectAnswer { get; set; }

		[JsonProperty("difficulty")]
		public string Difficulty { get; set; }

		[JsonProperty("incorrect_answers")]
		public List<string> IncorrectAnswers { get; set; }

		[JsonProperty("question")]
		public string QuestionText { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
