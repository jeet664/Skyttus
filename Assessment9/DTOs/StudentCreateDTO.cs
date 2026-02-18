using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOs
{
    public class StudentCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        public string Course { get; set; }
    }
}
