using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Dtos.Student
{
    public class StudentUpdateDto
    {
        [Required]
        public string name { get; set; }
    }
}