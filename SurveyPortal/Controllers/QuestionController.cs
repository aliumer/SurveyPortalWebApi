using Microsoft.AspNetCore.Mvc;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;
using SurveyPortal.Services;

namespace SurveyPortal.Controllers
{
    [Route("question")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("create")]
        public async Task CreateQuestion(Question question)
        {
            await _questionService.CreateQuestion(question);
        }

        [HttpPut("update")]
        public async Task UpdateQuestion(Question question)
        {
            await _questionService.UpdateQuestion(question);
        }

        [HttpGet("list/{survey-id}")]
        public async Task<List<Question>> GetQuestionsBySurveyId([FromRoute(Name = "survey-id")] int id)
        {
            return await _questionService.GetQuestionsBySurveyId(id);
        }

        [HttpGet("{question-id}")]
        public async Task<Question> GetQuestionById([FromRoute(Name = "question-id")] int id)
        {
            return await _questionService.GetQuestionById(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestion(id);
        }

    }
}
