using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;

namespace SurveyPortal.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeesService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeesService = employeeService;
        }

        [HttpPost("create")]
        public async Task CreateEmployee(Employee employee)
        {
            await _employeesService.CreateEmployee(employee);
        }

        [HttpPut("update")]
        public async Task UpdateEmployee(Employee employee)
        {
            await _employeesService.UpdateEmployee(employee);
        }

        [HttpGet("list")]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeesService.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeesService.GetEmployeeById(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployee(id);
        }


    }
}
