using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbModel.Entity;

namespace SurveyPortal.Domain.Contracts
{
    public interface IDataContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Survey> Surveys { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Option> Options { get; set; }

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
