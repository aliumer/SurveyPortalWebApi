using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbModel.Entity;
using SurveyPortal.Domain.Contracts;

namespace SurveyPortal.DbPersistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext>options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Survey>().HasKey(s => s.Id);
            modelBuilder.Entity<Question>().HasKey(s => s.Id);
            modelBuilder.Entity<Option>().HasKey(s => s.Id);

        }

    }
}
