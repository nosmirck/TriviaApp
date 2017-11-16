using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.Models;

namespace TriviaApp.Business
{
    public interface ITriviaService
    {
		Task<List<Question>> GetQuestions();
    }
}
