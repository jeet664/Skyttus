using System.ComponentModel.DataAnnotations;

namespace Assessment6.Models
{
    public class Assessment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Range(0, 100, ErrorMessage = "Total Marks must be between 0 and 100")]
        public int TotalMarks { get; set; }
    }
}
