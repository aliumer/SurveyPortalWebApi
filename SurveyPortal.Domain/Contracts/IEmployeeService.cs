using SurveyPortal.DbModel.Entity;

namespace SurveyPortal.Domain.Contracts
{
    public interface IEmployeeService
    {
        Task CreateEmployee(Employee employee);
        Task DeleteEmployee(int Id);
        Task UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployees();

    }
}
