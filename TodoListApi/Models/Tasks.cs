namespace TodoListApi.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status TaskStatus { get; set; } = Status.Peding;
        public int UserId { get; set; }
        public enum Status
        {
            Peding = 1,
            InProgress = 2,
            Done = 3,
            Canceled = 4
        }
    }
}
