using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain
{
    public class Task
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        
        public int Priority { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }

        [IgnoreDataMember]
        public string StatusName => Enum.GetName(typeof(Status), Status);
        [IgnoreDataMember]
        public string PriorityName => Enum.GetName(typeof(Priority), Priority);
    }
}
