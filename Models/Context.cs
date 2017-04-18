using Microsoft.EntityFrameworkCore;

namespace basic_html_css.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Task");            
        }
    
    }
}