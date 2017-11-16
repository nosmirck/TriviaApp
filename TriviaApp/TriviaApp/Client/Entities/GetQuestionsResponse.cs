using Newtonsoft.Json;
using System.Collections.Generic;
using TriviaApp.Models;

namespace TriviaApp.Client.Entities
{
	public class GetQuestionsResponse
	{
		[JsonProperty("response_code")]
		public ResponseCode Status { get; set; }

		[JsonProperty("results")]
		public List<Question> Questions { get; set; }
	}

	public enum ResponseCode
	{
		Success = 0,
		NoResults,
		InvalidParameter,
		TokenNotFound,
		TokenEmpty
	}
}