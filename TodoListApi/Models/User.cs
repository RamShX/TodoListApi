using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordH { get; set; }
    }
}
