using System.Threading.Tasks;

namespace Ingenum.Case.Core.Repository
{
    using Ingenum.Case.Model.Database;

    public interface ITodoTaskRepository : IBaseRepository<TodoTask>
    {
        public Task<bool> UpdateTableAsync(string taskId, string newTableId);
    }
}
