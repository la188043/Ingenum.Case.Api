using System.Security.AccessControl;

namespace Ingenum.Case.EntityFramework.Repository
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Model.Database;

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

        public async Task<bool> UpdateTableAsync(string taskId, string newTableId)
        {
            var taskToMove = await context.Tasks
                .FirstOrDefaultAsync(x => x.Id == taskId);

            if (taskToMove != null)
            {
                taskToMove.TableId = newTableId;

                this.context.Update(taskToMove);

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
