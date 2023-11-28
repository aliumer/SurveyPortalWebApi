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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(q => q.Questions)
                    .WithOne(entity => entity.Survey)
                    .HasForeignKey(entity => entity.SurveyId)
                    .HasPrincipalKey(e => e.Id);
            });

            modelBuilder.Entity<Question>(entity => 
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(q => q.Survey)
                    .WithMany(x => x.Questions)
                    .HasForeignKey(x => x.SurveyId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Options)
                    .WithOne(e => e.Question)
                    .HasForeignKey(e => e.QuestionId);

            });

            modelBuilder.Entity<Option>(entity => 
            {
                entity.HasKey(e => e.Id); 
            });

        }

    }
}
