using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basic_html_css.Models
{
    public class Task
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int JenisTask { get; set; }
        public string Deskripsi { get; set; }
        public bool Publish { get; set; }
        public int EffortTask { get; set; }
    }
}