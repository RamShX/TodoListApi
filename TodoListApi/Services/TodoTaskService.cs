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

        public TodoTasks CreateTask(TodoTasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public bool DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            return _context.SaveChanges() > 0;
            
        }

        //Es un solo registro!
        public TodoTasks GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public List<TodoTasks> GetTaskByIdUser(int id)
        {
            return _context.Tasks.Where(t => t.UserId == id).ToList();
        }

        public List<TodoTasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public TodoTasks UpdateTask(TodoTasks task)
        {
            var existingTask = _context.Tasks.Find(task.Id);

            if (existingTask == null)
                return null;

            _context.Entry(existingTask).CurrentValues.SetValues(task);
            _context.SaveChanges();
            return existingTask;
        }
    }
}
