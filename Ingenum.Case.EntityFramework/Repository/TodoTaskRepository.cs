namespace Ingenum.Case.EntityFramework.Repository
{
    using System;
    using System.Threading.Tasks;
    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Model.Database;
    using Microsoft.EntityFrameworkCore;

    public class TodoTaskRepository : BaseRepository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(ApiContext context) : base(context)
        {
        }

        public override async Task<bool> DeleteAsync(string id)
        {
            var taskToDelete = await context.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);

            if (taskToDelete != null)
            {
                taskToDelete.IsDeleted = true;

                this.context.Update(taskToDelete);

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
