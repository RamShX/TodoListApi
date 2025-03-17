using TodoListApi.Interfeces;
using TodoListApi.Models;
using TodoListApi.Context;

namespace TodoListApi.Services
{
    public class UserService : IUser
    {
        private readonly TodoListContext _context;
        public UserService(TodoListContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
