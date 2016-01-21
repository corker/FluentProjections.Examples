using System;
using System.Collections.Generic;
using System.Web.Http;
using FluentProjections.Examples.TodoMVC.ReadModels;
using FluentProjections.Examples.TodoMVC.ReadModels.Messages;
using FluentProjections.Examples.TodoMVC.ReadModels.Models;

namespace FluentProjections.Examples.TodoMVC.Web.Controllers
{
    public class TodoController : ApiController
    {
        private readonly TodoItemMessageHandler _handler;
        private readonly TodoItemProvider _provider;

        public TodoController(TodoItemMessageHandler handler, TodoItemProvider provider)
        {
            _handler = handler;
            _provider = provider;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _provider.GetAll();
        }

        [HttpPost]
        public string PostTodoItem(PostTodoItemModel model)
        {
            var id = Guid.NewGuid().ToString();
            var message = new PostTodoItem(id, model.Text);
            _handler.Handle(message);
            return id;
        }

        [HttpPost]
        public void CompleteTodoItem(string id)
        {
            var message = new CompleteTodoItem(id);
            _handler.Handle(message);
        }

        [HttpPost]
        public void DeleteTodoItem(string id)
        {
            var message = new DeleteTodoItem(id);
            _handler.Handle(message);
        }
    }
}