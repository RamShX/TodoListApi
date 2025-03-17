using TodoListApi.Context;
using TodoListApi.Interfeces;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class TodoTaskService : ITask
    {
        private readonly TodoListContext _context;

        public TodoTaskService(TodoListContext context)
        {
            _context = context;
        }

        public List<TodoTasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }
    }
}
