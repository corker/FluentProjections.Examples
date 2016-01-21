using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FluentProjections.Examples.TodoMVC.ReadModels.Models;

namespace FluentProjections.Examples.TodoMVC.ReadModels
{
    public class TodoItemProvider
    {
        private readonly IDbConnection _connection;

        public TodoItemProvider(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _connection.Query<TodoItem>("SELECT * FROM TodoItem").ToArray();
        }
    }
}