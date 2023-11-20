using Microsoft.EntityFrameworkCore;
using SurveyPortal.DbPersistence;
using SurveyPortal.Domain.Contracts;
using SurveyPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDataContext>(s => s.GetRequiredService<DataContext>());

if (builder != null)
{
    string connectionString = builder.Configuration.GetConnectionString("SurveyPortalDbConnection");
    builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SurveyPortal v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
