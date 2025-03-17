using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; } = string.Empty;
        public Status TaskStatus { get; set; } = Status.Pending;
        public int UserId { get; set; }
        public enum Status
        {
            Pending = 1,
            InProcess = 2,
            Done = 3,
            Canceled = 4
        }
    }
}
