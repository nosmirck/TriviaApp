using CF.RESTClientDotNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using TriviaApp.Models;
using TriviaApp.Client.Adapters;
using TriviaApp.Client.Constants;
using TriviaApp.Client.Entities;

namespace TriviaApp.Client
{
	public class TriviaRepository : ITriviaRepository
	{

		public async Task<List<Question>> GetQuestions()
		{
			try
			{
				var restClient = new RESTClient(new SerializationAdapter(), new Uri(ApplicationConstants.Endpoints.TriviaBaseUrl, "api.php?amount=10"));
				var response = await restClient.GetAsync<GetQuestionsResponse>();
				if(response == null)
				{
					throw new Exception(restClient.ErrorType.FullName);
				}
				if (response.Status == ResponseCode.Success)
				{
					return response.Questions;
				}
				else
				{
					throw new Exception(response.Status.ToString());
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
