using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoListApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        // No aparece en respuestas de la API en swagger
        [JsonIgnore]
        public string PasswordH { get; set; }
    }
}
