using SurveyPortal.DbModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPortal.Domain.Contracts
{
    public interface IQuestionService
    {
        Task CreateQuestion(Question question);
        Task DeleteQuestion(int id);
        Task UpdateQuestion(Question question);
        Task<List<Question>> GetQuestionsBySurveyId(int id);
        Task<Question> GetQuestionById(int id);
    }
}
