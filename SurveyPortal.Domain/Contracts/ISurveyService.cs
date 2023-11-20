using SurveyPortal.DbModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPortal.Domain.Contracts
{
    public interface ISurveyService
    {
        Task CreateSurvey(Survey survey);
        Task DeleteSurvey(int id);
        Task UpdateSurvey(Survey survey);
        Task<Survey> GetSurvey(int id);
        Task<List<Survey>> GetSurveys();

    }
}
