using System.ComponentModel.DataAnnotations;

namespace Crud_Using_ADO.Net.Models
{
    public class Book
    {
        [Key]//to define this is a PK col in DB
        [ScaffoldColumn(false)]//Bcoz this is identity col, no need to display on form
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }//string?-->to allow null from DB
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Author { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
