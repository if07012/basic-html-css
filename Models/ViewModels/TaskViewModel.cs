using Microsoft.EntityFrameworkCore;

namespace basic_html_css.Models.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JenisTask { get; set; }
        public string Deskripsi { get; set; }
        public bool Publish { get; set; }
        public int EffortTask { get; set; }
        public string Message { get; internal set; }
        public DbSet<Task> List { get; internal set; }
    }
}