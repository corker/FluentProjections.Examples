namespace FluentProjections.Examples.TodoMVC.ReadModels.Messages
{
    public class DeleteTodoItem
    {
        public DeleteTodoItem(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}