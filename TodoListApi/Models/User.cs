using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoListApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordH { get; set; }
    }
}
