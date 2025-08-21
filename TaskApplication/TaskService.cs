using TaskApplication.Interface;
using Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TaskApplication
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _dbContext;

        public TaskService(TaskDbContext taskDbContext) { _dbContext = taskDbContext; }

        public async Task<bool> DeleteTask(int id)
        {
            var found = await _dbContext.Tasks.FindAsync(id);

            if (found is null)
            {
                return false;
            }
            else { 
                _dbContext.Remove(found);
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Task?> GetTask(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            return task;
        }

        public async Task<IEnumerable<Domain.Task>> GetTasks(int? status, int? priority)
        {
            var sql = _dbContext.Tasks.AsNoTracking();

            if (status is not null)
            {
                sql = sql.Where(x => x.Status == status);
            }

            if(priority is not null)
            {
                sql = sql.Where(x => x.Priority == priority);
            }
            return await sql.ToListAsync();

            //return await sql.Skip((page - 1) * pageSize)
            //                .Take(pageSize)
            //                .ToListAsync();
        }

        public async Task<Domain.Task> InsertTask(Domain.Task item)
        {
            await _dbContext.Tasks.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateTask(Domain.Task item)
        {
            
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TaskExistAsync(int Id) => await _dbContext.Tasks.AnyAsync(t => t.Id == Id);
    }
}
