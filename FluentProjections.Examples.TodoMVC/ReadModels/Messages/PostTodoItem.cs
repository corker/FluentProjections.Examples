namespace FluentProjections.Examples.TodoMVC.ReadModels.Messages
{
    public class PostTodoItem
    {
        public PostTodoItem(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; }
        public string Text { get; }
    }
}