using TodoListApi.Models;

namespace TodoListApi.Interfeces
{
    public interface ITask
    {
        List<TodoTasks> GetTasks();
    }
}
