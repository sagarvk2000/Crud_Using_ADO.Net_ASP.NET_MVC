using System.ComponentModel.DataAnnotations;

namespace Crud_Using_ADO.Net.Models
{
    public class Student
    {
        [Required]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double Percentage { get; set; }

        [Required]
        public string? Course { get; set; }

        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
