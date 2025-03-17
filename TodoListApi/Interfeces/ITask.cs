using TodoListApi.Models;

namespace TodoListApi.Interfeces
{
    public interface ITask
    {
        List<TodoTasks> GetTasks();
        List<TodoTasks> GetTaskByIdUser(int id);
        TodoTasks GetTaskById(int id);
        TodoTasks CreateTask(TodoTasks task);
        TodoTasks UpdateTask(TodoTasks task);
        bool DeleteTask(int id);

    }
}
