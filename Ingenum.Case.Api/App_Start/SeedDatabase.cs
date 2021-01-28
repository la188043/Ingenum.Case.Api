
namespace Ingenum.Case.Api.App_Start
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.EntityFramework;
    using Ingenum.Case.Model.Database;

    public class SeedDatabase
    {
        public static async Task Initialize(
            ApiContext context,
            ITableRepository tableRepository,
            ITodoTaskRepository todoTaskRepository)
        {
            context.Database.EnsureCreated();

            if (!context.Tables.Any())
            {
                var todoTableTodoInDb = await tableRepository.CreateAsync(new Table { Name = "Todo" });
                var todoTableDoingInDb = await tableRepository.CreateAsync(new Table { Name = "Doing" });
                var todoTableDoneInDb = await tableRepository.CreateAsync(new Table { Name = "Done" });

                await todoTaskRepository.CreateAsync(new TodoTask
                {
                    Name = "Faire une API",
                    DueDate = DateTime.Now,
                    Description = "Créer une API en .NET 5",
                    TableId = todoTableDoingInDb.Id
                });

                await todoTaskRepository.CreateAsync(new TodoTask
                {
                    Name = "Faire l'application client",
                    DueDate = DateTime.Now,
                    Description = "Créer une application React avec TypeScript",
                    TableId = todoTableTodoInDb.Id
                });

                await todoTaskRepository.CreateAsync(new TodoTask
                {
                    Name = "Prendre en main MacOS",
                    DueDate = DateTime.Now,
                    Description = "Description",
                    TableId = todoTableDoneInDb.Id
                });

                await todoTaskRepository.CreateAsync(new TodoTask
                {
                    Name = "Apprendre les raccourcis clavier Visual Studio",
                    DueDate = DateTime.Now,
                    Description = "Apprendre les raccourcis clavier Visual Studio + quelques mots",
                    TableId = todoTableTodoInDb.Id
                });
            }
        }
    }
}
