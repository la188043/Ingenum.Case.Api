namespace Ingenum.Case.Core.Services
{
    using System.Threading.Tasks;
    
    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Model.Database;
    using Ingenum.Case.Model.DTO;

    public interface ITodoTaskService : IBaseService<TodoTaskDto, AddTodoTaskDto, TodoTask, ITodoTaskRepository>
    {
        public Task<bool> UpdateTableAsync(string id, string newTableId);
    }
}
