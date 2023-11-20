using Microsoft.AspNetCore.Mvc;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;
using SurveyPortal.Services;

namespace SurveyPortal.Controllers
{
    [Route("survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("list")]
        public async Task<List<Survey>> GetSurveys()
        {
            return await _surveyService.GetSurveys();
        }

        [HttpGet("{id}")]
        public async Task<Survey> GetSurveyById(int id)
        {
            return await _surveyService.GetSurvey(id);
        }

        [HttpPost("create")]
        public async Task CreateSurvey(Survey survey)
        {
            await _surveyService.CreateSurvey(survey);
        }

        [HttpPut("update")]
        public async Task UpdateSurvey(Survey survey)
        {
            await _surveyService.UpdateSurvey(survey);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSurvey(int id)
        {
            await _surveyService.DeleteSurvey(id);
        }
    }
}
