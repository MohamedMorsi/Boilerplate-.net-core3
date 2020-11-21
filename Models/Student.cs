using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
    }
}