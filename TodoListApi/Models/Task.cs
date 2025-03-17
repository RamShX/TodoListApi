namespace TodoListApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
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
