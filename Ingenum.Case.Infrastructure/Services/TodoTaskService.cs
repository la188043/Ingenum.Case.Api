using AutoMapper;
using Ingenum.Case.Core.Repository;
using Ingenum.Case.Core.Services;
using Ingenum.Case.Model.Database;
using Ingenum.Case.Model.DTO;

namespace Ingenum.Case.Infrastructure.Services
{
    public class TodoTaskService : BaseService<TodoTaskDto, AddTodoTaskDto, TodoTask, ITodoTaskRepository>, ITodoTaskService
    {
        public TodoTaskService(ITodoTaskRepository todoTaskRepository, IMapper mapper) : base(todoTaskRepository, mapper)
        {
        }
    }
}
