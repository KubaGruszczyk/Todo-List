using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private readonly IWorkTaskService _workTaskService;

        public TodoListController(IWorkTaskService workTaskService)
        {
            _workTaskService = workTaskService;
        }
        public async Task<ActionResult> Index()
        {
            var workTasks = await _workTaskService.GetIncompleteTasksAsync();
            return View(workTasks);
        }
        public async Task<ActionResult> WorkTaskDetails(int id)
        {
            var workTask = await _workTaskService.GetTaskByIdAsync(id);
            return View(workTask);
        }
        [HttpGet]
        public async Task<ActionResult> FindWorkTasksByDate(DateTime date)
        {
            var workTasks = await _workTaskService.GetTasksByDateAsync(date);
            return View("Index", workTasks);
        }
        public async Task<PartialViewResult> GetNotifications()
        {
            var today = DateTime.Today;
            var tasksForToday = await _workTaskService.GetTasksByDateAsync(today);
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
            if (ModelState.IsValid)
            {
                workTask.CreatedAt = DateTime.Now; // Ustawienie daty utworzenia w serwisie
                await _workTaskService.CreateWorkTaskAsync(workTask);
                return RedirectToAction("Index");
            }
            return View(workTask);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var workTask = await _workTaskService.GetTaskByIdAsync(id);
            return View(workTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit (WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                workTask.CreatedAt = DateTime.Now; // Ustawienie daty utworzenia w serwisie
                await _workTaskService.UpdateWorkTaskAsync(workTask);
                return RedirectToAction("Index");
            }
            return View(workTask);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var workTask = await _workTaskService.GetTaskByIdAsync(id);
            return View(workTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(WorkTask workTask)
        {
            await _workTaskService.DeleteWorkTaskAsync(workTask);
            return RedirectToAction("Index");
        }
    }
}
