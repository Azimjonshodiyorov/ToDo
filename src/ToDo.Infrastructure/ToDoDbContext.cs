using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.Domain.Common;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> dbContext)
            :base(dbContext) 
        {
            
        }


        public DbSet<Todo> Todos { get; set; }
        public DbSet<Categorey> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Todo>().HasKey(x=>x.Id);
            modelBuilder.Entity<Todo>().Property(x=>x.Title).HasMaxLength(5000).IsRequired();


            modelBuilder.Entity<Categorey>().HasKey(x=>x.Id);
            modelBuilder.Entity<Categorey>().Property(x=>x.Name).HasMaxLength(5000).IsRequired();


            modelBuilder.Entity<Todo>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Todos)
                .HasForeignKey(x => x.CategoryId);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity<long>>())
            {
                switch(item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreateAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                            item.Entity.UpdateAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        item.Entity.DeleteAt = DateTime.Now;    
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
