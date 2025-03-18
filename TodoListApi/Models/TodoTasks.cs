using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TodoListApi.Models
{
    public class TodoTasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        public string DescriptionT { get; set; } = string.Empty;
        //Convierte el enum a string en JSON
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status TaskStatus { get; set; } = Status.Pending;
        public int UserId { get; set; }
        public enum Status
        {
            [EnumMember(Value = "Pending")]
            Pending,
            [EnumMember(Value = "InProcess")]
            InProcess,
            [EnumMember(Value = "Done")]
            Done,
            [EnumMember(Value = "Canceled")]
            Canceled
        }
    }
}

