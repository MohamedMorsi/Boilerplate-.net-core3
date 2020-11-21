using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Dtos.Student
{
    public class StudentCreateDto
    {
        [Required]
        public string name { get; set; }
    }
}