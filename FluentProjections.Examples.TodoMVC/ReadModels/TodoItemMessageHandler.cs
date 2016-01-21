using FluentProjections.Examples.TodoMVC.ReadModels.Messages;
using FluentProjections.Examples.TodoMVC.ReadModels.Models;
using FluentProjections.Persistence;

namespace FluentProjections.Examples.TodoMVC.ReadModels
{
    public class TodoItemMessageHandler : MessageHandler<TodoItem>
    {
        public TodoItemMessageHandler(ICreateProjectionProviders factory) : base(factory)
        {
        }

        public void Handle(PostTodoItem message)
        {
            Handle(message, m => m
                .AddNew()
                .Map(x => x.Id)
                .Map(x => x.Text)
                .Set(x => x.Completed, false));
        }

        public void Handle(CompleteTodoItem message)
        {
            Handle(message, m => m
                .Update()
                .WhenEqual(x => x.Id)
                .Set(x => x.Completed, true));
        }

        public void Handle(DeleteTodoItem message)
        {
            Handle(message, m => m
                .Remove()
                .WhenEqual(x => x.Id));
        }
    }
}