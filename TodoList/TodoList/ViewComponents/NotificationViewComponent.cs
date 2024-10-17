using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly WorkTaskDBContext _dbContext;

    public NotificationViewComponent(WorkTaskDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var today = DateTime.Today;

        // Pobierz zadania na dzisiaj
        var tasksForToday = await _dbContext.WorkTasks
            .Where(wt => wt.ExpectedEndDate.Date == today)
            .ToListAsync();

        return View("_NotificationPartial", tasksForToday);
    }
}
}
