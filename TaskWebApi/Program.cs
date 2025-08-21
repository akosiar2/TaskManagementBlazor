using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;
using Database;
using System;
using TaskApplication.Interface;
using TaskApplication;

var builder = WebApplication.CreateBuilder(args);

// EF Core InMemory
builder.Services.AddDbContext<TaskDbContext>(opt =>
    opt.UseInMemoryDatabase("DemoDb"));

// Add services to the container.
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    if (!db.Tasks.Any())
    {
        db.Tasks.AddRange(
            new Task
            {
                Id = 1,
                Title = "Fix login bug",
                Description = "Users are unable to log in with Google OAuth",
                Status = 1,
                Priority = 1,
                CreatedDate = DateTime.Now.AddDays(-2),
                DueDate = DateTime.Now.AddDays(2)
            },
                new Task
                {
                    Id = 2,
                    Title = "Write API documentation",
                    Description = "Add Swagger annotations for public endpoints",
                    Status = 1,
                    Priority = 2,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(5)
                },
                new Task
                {
                    Id = 3,
                    Title = "Update dependencies",
                    Description = "Upgrade to EF Core 8 and test migrations",
                    Status = 3,
                    Priority = 3,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    DueDate = null
                },
                new Task
                {
                    Id = 4,
                    Title = "Add new feature",
                    Description = "Search feature",
                    Status = 1,
                    Priority = 1,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    DueDate = DateTime.Now.AddDays(10)
                },
                new Task
                {
                    Id = 5,
                    Title = "Write Blazor Docs",
                    Description = "Add written documentation for frontend",
                    Status = 1,
                    Priority = 2,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(5)
                },
                new Task
                {
                    Id = 6,
                    Title = "Update logs",
                    Description = "Include tracing",
                    Status = 2,
                    Priority = 1,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    DueDate = null
                },
                new Task
                {
                    Id = 7,
                    Title = "Fix login bug",
                    Description = "Users are unable to log in with Google OAuth",
                    Status = 1,
                    Priority = 1,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    DueDate = DateTime.Now.AddDays(2)
                },
                new Task
                {
                    Id = 8,
                    Title = "Write API documentation",
                    Description = "Add Swagger annotations for public endpoints",
                    Status = 1,
                    Priority = 2,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(5)
                },
                new Task
                {
                    Id = 9,
                    Title = "Update dependencies",
                    Description = "Upgrade to EF Core 8 and test migrations",
                    Status = 2,
                    Priority = 3,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    DueDate = null
                },
                new Task
                {
                    Id = 10,
                    Title = "Write API documentation",
                    Description = "Add Swagger annotations for public endpoints",
                    Status = 1,
                    Priority = 2,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(5)
                },
                new Task
                {
                    Id = 11,
                    Title = "Update dependencies",
                    Description = "Upgrade to EF Core 8 and test migrations",
                    Status = 2,
                    Priority = 3,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    DueDate = null
                }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
