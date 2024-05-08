namespace ASPNETAPIDay1.Model
{
    public class ToDoTask
    {
        public ToDoTask() { }

        public ToDoTask(string title, bool isCompleted, Guid id)
        {
            Title = title;
            IsCompleted = isCompleted;
            this.id = id;
        }

        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid id { get; set; }


    }
}
