using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Client;
using TriviaApp.Models;

namespace TriviaApp.Business
{
	public class TriviaService : ITriviaService
	{
		ITriviaRepository _triviaRepository;
		public TriviaService()
		{
			_triviaRepository = new TriviaRepository();
		}
		public async Task<List<Question>> GetQuestions()
		{
			try
			{
				return await _triviaRepository.GetQuestions();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
