using System.ComponentModel.DataAnnotations;

namespace TaskBlazor.Model
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Priority is required.")]
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public string StatusName { get; set; }
        public string PriorityName { get; set; }
    }
}
