namespace TodoAppBackend.Models
{
    public class TaskModel
    {
        //public int Id { get; set; }
        public string title { get; set; } = "";
        public string description { get; set; } = "";

        public bool isCompleted { get; set; }
    }
}
