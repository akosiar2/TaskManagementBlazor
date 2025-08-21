using TaskBlazor.Model;

namespace TaskBlazor.Services
{
    public class TaskService
    {
        public async static Task<List<TaskViewModel>> GetTasks(int? status, int? priority)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetFromJsonAsync<List<TaskViewModel>>($"https://localhost:7280/tasks?status={status}&priority={priority}");
            
            return result;
        }

        public async static Task<TaskViewModel> GetTask(int id)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetFromJsonAsync<TaskViewModel>($"https://localhost:7280/tasks/{id}");

            return result;
        }

        public async static Task<bool> CreateTask(TaskViewModel task)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync<TaskViewModel>($"https://localhost:7280/tasks", task);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public async static Task<bool> UpdateTask(TaskViewModel task)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync<TaskViewModel>($"https://localhost:7280/tasks/{task.Id}", task);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public async static Task<bool> DeleteTask(int taskId)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"https://localhost:7280/tasks/{taskId}");
            response.EnsureSuccessStatusCode();

            return true;
        }

    }
}
