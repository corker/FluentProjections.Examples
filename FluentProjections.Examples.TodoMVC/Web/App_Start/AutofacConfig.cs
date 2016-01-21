using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DapperExtensions.Sql;
using FluentProjections.Examples.TodoMVC.ReadModels;
using FluentProjections.Persistence;
using FluentProjections.Persistence.SQL;

namespace FluentProjections.Examples.TodoMVC.Web
{
    public static class AutofacConfig
    {
        private static readonly string ConnectionString;

        static AutofacConfig()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();
            ConnectionString = ConfigurationManager.ConnectionStrings["TodoMVC"].ConnectionString;
        }

        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TodoItemMessageHandler>();
            builder.RegisterType<TodoItemProvider>();
            builder.Register(CreateProjectionProviderFactory);
            builder.Register(CreateDbConnection);

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IDbConnection CreateDbConnection(IComponentContext arg)
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        private static ICreateProjectionProviders CreateProjectionProviderFactory(IComponentContext context)
        {
            return new SqlPersistenceFactory(() => new SQLiteConnection(ConnectionString));
        }
    }
}