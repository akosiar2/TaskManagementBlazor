using Microsoft.EntityFrameworkCore;
using System;
namespace Database
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<Domain.Task> Tasks => Set<Domain.Task>();

    }
}
