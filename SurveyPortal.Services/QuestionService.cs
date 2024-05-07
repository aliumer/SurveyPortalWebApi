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
            var question = await _dataContext.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);
            //List<Option> options = await _dataContext.Options.Where(o => o.QuestionId  == id).ToListAsync<Option>();
            foreach (var o in question.Options)
            {
                _dataContext.Options.Remove(o);
            }
            _dataContext.Questions.Remove(question);
            await _dataContext.SaveChangesAsync(true);
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _dataContext.Questions.Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Question>> GetQuestionsBySurveyId(int id)
        {
            return await _dataContext.Questions.Where(q => q.Survey.Id == id).ToListAsync();
        }


        public async Task UpdateQuestion(Question question)
        {
            try
            {
                Question q = await _dataContext.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == question.Id);

                foreach (var option in q.Options)
                {
                    _dataContext.Options.Remove(option);
                }
                q.SurveyId = question.SurveyId;
                q.Options = question.Options;
                q.QuestionText = question.QuestionText;
                q.QuestionType = question.QuestionType;

                await _dataContext.SaveChangesAsync(true);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                throw;
            }
        }

    }
}
