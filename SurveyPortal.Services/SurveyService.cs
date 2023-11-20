using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;

namespace SurveyPortal.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IDataContext _dataContext;
        public SurveyService(IDataContext datacontext)
        {
            _dataContext = datacontext;
        }
        public async Task CreateSurvey(Survey survey)
        {
            _dataContext.Surveys.Add(survey);
            await _dataContext.SaveChangesAsync(true);
        }

        public async Task DeleteSurvey(int id)
        {
            Survey survey = (Survey)_dataContext.Surveys.Where(s => s.Id == id);
            _dataContext.Surveys.Remove(survey);
            await _dataContext.SaveChangesAsync(true);
        }

        public async Task<Survey> GetSurvey(int id)
        {
            return await _dataContext.Surveys.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Survey>> GetSurveys()
        {
            return await _dataContext.Surveys.ToListAsync<Survey>();
        }

        public async Task UpdateSurvey(Survey survey)
        {
            Survey s = (Survey)_dataContext.Surveys.Where(s => s.Id == survey.Id);
            s.StartDate = survey.StartDate;
            s.EndDate = survey.EndDate;
            s.SurveyName = survey.SurveyName;
            s.Questions = survey.Questions;
            await _dataContext.SaveChangesAsync(true);
            
        }
    }
}
