using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class WorkTaskService : IWorkTaskService
    {
        private readonly WorkTaskDBContext _dbContext;

        public WorkTaskService(WorkTaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateWorkTaskAsync(WorkTask workTask)
        {
            await _dbContext.WorkTasks.AddAsync(workTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkTaskAsync(WorkTask workTask)
        {
            _dbContext.Remove(workTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WorkTask>> GetIncompleteTasksAsync()
        {
            return await _dbContext.WorkTasks.Where(wt => !wt.IsCompleted).ToListAsync();
        }

        public async Task<WorkTask> GetTaskByIdAsync(int id)
        {
            return await _dbContext.WorkTasks.FirstOrDefaultAsync(wt => wt.Id == id);
        }

        public async Task<List<WorkTask>> GetTasksByDateAsync(DateTime date)
        {
            return await _dbContext.WorkTasks
               .Where(wt => wt.ExpectedEndDate.Date == date.Date)
               .ToListAsync();
        }

        public async Task UpdateWorkTaskAsync(WorkTask workTask)
        {
            _dbContext.Update(workTask);
            await _dbContext.SaveChangesAsync();
        }
    }
}
