using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Models;

namespace TriviaApp.Client
{
	public interface ITriviaRepository
	{
		Task<List<Question>> GetQuestions();
	}
}
