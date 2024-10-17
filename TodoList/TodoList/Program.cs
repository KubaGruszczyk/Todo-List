using Microsoft.EntityFrameworkCore;
using TodoList.Entities;
using TodoList.Services.Interfaces;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<WorkTaskDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnectionString")));

builder.Services.AddScoped<IWorkTaskService, WorkTaskService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WorkTaskDBContext>();

    var workTasks = dbContext.WorkTasks.ToList();

    if(!workTasks.Any())
    {
        dbContext.WorkTasks.AddRange(
                    new WorkTask()
                    {
                        Title = "Skosic Trawe",
                        Description = "Skosic trawe wokol domu. Wyczyscic kosiarke po wykonaniu zadania oraz odlozyc na miejsce w garazu.",
                        ExpectedEndDate = DateTime.Now.AddDays(7),
                        CreatedAt = DateTime.Now,
                        IsCompleted = false,
                    },
                    new WorkTask()
                    {
                        Title = "Posprzatac w domu",
                        Description = "Odkurzyc w kazdym pokoju po czym zmyc podlogi.",
                        ExpectedEndDate = DateTime.Now.AddDays(4),
                        CreatedAt = DateTime.Now.AddDays(-2),
                        IsCompleted = false,
                    },
                    new WorkTask()
                    {
                        Title = "Kupic zakupy",
                        Description = "Zrobic zakupy spozywcze na tydzien.",
                        ExpectedEndDate = DateTime.Now.AddDays(2),
                        CreatedAt = DateTime.Now,
                        IsCompleted = false,
                    },
                    new WorkTask()
                    {
                        Title = "Zrobic pranie",
                        Description = "Wstawic pranie i rozwiesic je po umyciu.",
                        ExpectedEndDate = DateTime.Now.AddDays(1),
                        CreatedAt = DateTime.Now,
                        IsCompleted = false,
                    },
                    new WorkTask()
                    {
                        Title = "Naprawic komputer",
                        Description = "Sprawdzic usterki komputera i zglosic je do serwisu.",
                        ExpectedEndDate = DateTime.Now.AddDays(3),
                        CreatedAt = DateTime.Now,
                        IsCompleted = false,
                    }
                );
        await dbContext.SaveChangesAsync();
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TodoList}/{action=Index}/{id?}");

app.Run();
