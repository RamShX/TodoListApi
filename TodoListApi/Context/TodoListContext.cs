using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> dbContext) : base(dbContext) {}

        public DbSet<TodoTasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        //Configuracion de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Especificar los nombres de las tablas
            modelBuilder.Entity<TodoTasks>().ToTable("TodoTasks");
            modelBuilder.Entity<User>().ToTable("Users");

            //Configuración de las propiedades
            modelBuilder.Entity<TodoTasks>().Property(t => t.TaskStatus)
                .HasConversion<string>();
        }
    }
}
