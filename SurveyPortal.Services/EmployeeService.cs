using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;

namespace SurveyPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataContext _context;
        public EmployeeService(IDataContext context) 
        {
            _context = context;
        }
        public async Task CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(true);
        }

        public async Task DeleteEmployee(int Id)
        {
            Employee emp = (Employee)_context.Employees.Where(e => e.Id == Id);
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync(true);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            Employee emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            await _context.SaveChangesAsync(true);
        }
    }
}
