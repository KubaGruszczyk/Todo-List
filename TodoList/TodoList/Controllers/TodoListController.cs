using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private readonly WorkTaskDBContext _dbContext;
        public TodoListController(WorkTaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult> Index()
        {
            var workTasks = await _dbContext.WorkTasks.Where(wt=>wt.IsCompleted == false).ToListAsync();
            return View(workTasks);
        }
        public async Task<ActionResult> WorkTaskDetails(int id)
        {
            var workTask = await _dbContext.WorkTasks.FirstOrDefaultAsync(WT => WT.Id == id);
            return View(workTask);
        }
        [HttpGet]
        public async Task<ActionResult> FindWorkTasksByDate(DateTime date)
        {
            var workTasks = await _dbContext.WorkTasks
                .Where(wt => wt.ExpectedEndDate.Date == date.Date) 
                .ToListAsync();
            return View("Index", workTasks);
        }
        public async Task<PartialViewResult> GetNotifications()
        {
            var today = DateTime.Today;
            var tasksForToday = await _dbContext.WorkTasks
                .Where(wt => wt.ExpectedEndDate.Date == today)
                .ToListAsync();

            return PartialView("_NotificationPartial", tasksForToday);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WorkTask workTask)
        {
            var workTaskToAdd = new WorkTask();
            if(ModelState.IsValid)
            {
                workTaskToAdd.Title = workTask.Title;
                workTaskToAdd.Description = workTask.Description;
                workTaskToAdd.ExpectedEndDate = workTask.ExpectedEndDate;
                workTaskToAdd.CreatedAt = DateTime.Now;
                await _dbContext.AddAsync(workTaskToAdd);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var workTask = await _dbContext.WorkTasks.FirstOrDefaultAsync(wt => wt.Id == id);
            return View(workTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit (WorkTask workTask)
        {
            if(ModelState.IsValid)
            {
                workTask.CreatedAt = DateTime.Now;
                _dbContext.Update(workTask);
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var workTask = await _dbContext.WorkTasks.FirstOrDefaultAsync(wt => wt.Id == id);
            return View(workTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(WorkTask workTask)
        {
            _dbContext.Remove(workTask);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
