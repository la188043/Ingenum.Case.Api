using System;
using System.Linq;
using System.Threading.Tasks;
using Ingenum.Case.Core.Repository;
using Ingenum.Case.EntityFramework;
using Ingenum.Case.Model.Database;

namespace Ingenum.Case.Api.App_Start
{
    public class SeedDatabase
    {
        public static async Task Initialize(ApiContext context, ITableRepository tableRepository)
        {
            context.Database.EnsureCreated();

            if (!context.Tables.Any())
            {
                var todoTableTodo = new Table { Name = "Todo" };
                var todoTableDoing = new Table { Name = "Doing" };
                var todoTableDone = new Table { Name = "Done" };

                await tableRepository.CreateAsync(todoTableTodo);
                await tableRepository.CreateAsync(todoTableDoing);
                await tableRepository.CreateAsync(todoTableDone);
            }
        }
    }
}
