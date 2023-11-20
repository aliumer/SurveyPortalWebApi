using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;

namespace SurveyPortal.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IDataContext _dataContext;
        public QuestionService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateQuestion(Question question)
        {
            _dataContext.Questions.Add(question);
            await _dataContext.SaveChangesAsync(true);
        }

        public async Task DeleteQuestion(int id)
        {
            Question question = (Question)_dataContext.Questions.Where(s => s.Id == id);
            _dataContext.Questions.Remove(question);
            await _dataContext.SaveChangesAsync(true);
        }

        public async Task<List<Question>> GetQuestionsBySurveyId(int id)
        {
            return await _dataContext.Questions.Where(q => q.Survey.Id == id).ToListAsync();
        }


        public async Task UpdateQuestion(Question question)
        {
            Question q = (Question)_dataContext.Questions.Where(q => q.Id == question.Id);
            q.Survey.Id = question.Survey.Id;
            q.Options = question.Options;
            q.QuestionText = question.QuestionText;
            q.QuestionType = question.QuestionType;
            await _dataContext.SaveChangesAsync(true);
        }
    }
}
