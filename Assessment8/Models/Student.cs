using System.ComponentModel.DataAnnotations;

namespace Assessment8.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Range(0,100)]
        public int Marks { get; set; }
    }
}
