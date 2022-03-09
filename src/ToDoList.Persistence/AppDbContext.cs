using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Domain.Common;
using ToDoList.Domain.Entities;

namespace ToDoList.Persistence
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
           LoadToDoTasks();
        }

        public DbSet<ToDoTask>  ToDoTasks { get; set; }

       

        private void LoadToDoTasks()
        {
            var currentDate = DateTime.Now;
            ToDoTasks.Add(new ToDoTask()
            {
                Title = "Task A",
                Description = "A Task for Task A",
                CreatedBy = "Task User",
                CreatedDate = currentDate,
                LastModifiedBy = "Task User",
                LastModifiedDate = currentDate
            });

            ToDoTasks.Add(new ToDoTask()
            {
                Title = "Task B",
                Description = "A Task for Task B",
                CreatedBy = "Task User",
                CreatedDate = currentDate,
                LastModifiedBy = "Task User",
                LastModifiedDate = currentDate
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = string.IsNullOrEmpty(entry.Entity.CreatedBy) ? "SYSTEM" : entry.Entity.CreatedBy;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = string.IsNullOrEmpty(entry.Entity.LastModifiedBy) ? "SYSTEM" : entry.Entity.LastModifiedBy;
                        break;                    
                }
                
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
