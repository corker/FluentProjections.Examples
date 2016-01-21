using DapperExtensions.Mapper;

namespace FluentProjections.Examples.TodoMVC.ReadModels.Models
{
    public class TodoItemMapper : ClassMapper<TodoItem>
    {
        public TodoItemMapper()
        {
            Map(x => x.Id).Key(KeyType.Assigned);
            Map(x => x.Text);
            Map(x => x.Completed);
        }
    }
}