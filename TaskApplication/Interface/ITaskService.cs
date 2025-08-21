

namespace TaskApplication.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Task>> GetTasks(int? status, int? priority);
        Task<Domain.Task?> GetTask(int id);
        Task<Domain.Task> InsertTask(Domain.Task item);
        Task<bool> UpdateTask(Domain.Task item);
        Task<bool> DeleteTask(int id);
        Task<bool> TaskExistAsync(int Id);
    }
}
