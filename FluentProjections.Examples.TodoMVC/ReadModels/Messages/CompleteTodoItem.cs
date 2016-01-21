namespace FluentProjections.Examples.TodoMVC.ReadModels.Messages
{
    public class CompleteTodoItem
    {
        public CompleteTodoItem(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}