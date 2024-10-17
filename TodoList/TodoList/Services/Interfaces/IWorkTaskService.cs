using TodoList.Entities;

namespace TodoList.Services.Interfaces
{
    public interface IWorkTaskService
    {
        Task<List<WorkTask>> GetIncompleteTasksAsync();
        Task<WorkTask> GetTaskByIdAsync(int id);
        Task<List<WorkTask>> GetTasksByDateAsync(DateTime date);
        Task CreateWorkTaskAsync(WorkTask workTask);
        Task UpdateWorkTaskAsync(WorkTask workTask);
        Task DeleteWorkTaskAsync(WorkTask workTask);
    }
}
