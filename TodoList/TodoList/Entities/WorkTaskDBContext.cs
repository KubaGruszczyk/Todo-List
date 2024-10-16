using Microsoft.EntityFrameworkCore;

namespace TodoList.Entities
{
    public class WorkTaskDBContext : DbContext
    {
        public WorkTaskDBContext(DbContextOptions<WorkTaskDBContext> options) : base(options) { }
        public DbSet<WorkTask> WorkTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkTask>()
                .HasData(new WorkTask()
                {
                    Id = 1,
                    Title = "Skosic Trawe",
                    Description = "Skosic trawe wokol domu. Wyczyscic kosiarke po wykonaniu zadania oraz odlozyc na miejsce w garazu.",
                    ExpectedEndDate = DateTime.Now.AddDays(7),
                    CreatedAt = DateTime.Now,
                    IsCompleted = false,
                },
                new WorkTask()
                {
                    Id = 2,
                    Title = "Posprzatac w domu",
                    Description = "Odkurzyc w kazdym pokoju po czym zmyc podlogi.",
                    ExpectedEndDate = DateTime.Now.AddDays(4),
                    CreatedAt = DateTime.Now.AddDays(-2),
                    IsCompleted = false,
                });
        }

    }
}
