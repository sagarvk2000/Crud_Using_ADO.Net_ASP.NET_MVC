using System.ComponentModel.DataAnnotations;

namespace Crud_Using_ADO.Net.Models
{
    public class Movies
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Mid { get; set; }
        [Required]
        public string? Mname { get; set; }
        [Required]
        public DateTime Rdate { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? Sname { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }

    }
}
