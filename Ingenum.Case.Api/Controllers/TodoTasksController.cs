namespace Ingenum.Case.Api.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Ingenum.Case.Model.DTO;
    using Ingenum.Case.Core.Services;

    [Route("tasks")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService todoTaskService;
        private readonly ITableService tableService;

        public TodoTasksController(ITodoTaskService todoTaskService, ITableService tableService)
        {
            this.todoTaskService = todoTaskService;
            this.tableService = tableService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TodoTaskDto>> Get(string id)
        {
            var todoTask = await this.todoTaskService.GetByIdAsync(id);

            if (todoTask == null)
            {
                return this.NotFound(id);
            }

            return this.Ok(todoTask);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTodoTaskDto todoTask)
        {
            if (todoTask == null)
            {
                return this.ValidationProblem();
            }

            var createdTodoTask = await this.todoTaskService.CreateAsync(todoTask);

            return createdTodoTask != null ? this.CreatedAtAction(
                nameof(Get), new { id = createdTodoTask.Id }, createdTodoTask
                ) : this.UnprocessableEntity() as IActionResult;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todoTask = await this.todoTaskService.GetByIdAsync(id);

            if (todoTask == null)
            {
                return this.NotFound();
            }

            var isDeleted = await this.todoTaskService.DeleteAsync(todoTask.Id);

            return isDeleted ? this.Ok(isDeleted) : this.UnprocessableEntity() as IActionResult;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(string id, TodoTaskDto newTodoTask)
        {
            var todoTask = await this.todoTaskService.GetByIdAsync(id);

            if (todoTask == null)
            {
                return this.NotFound();
            }

            if (newTodoTask == null)
            {
                return this.ValidationProblem();
            }

            var updatedTodoTask = await this.todoTaskService.UpdateAsync(id, newTodoTask);

            return updatedTodoTask != null ? this.NoContent() : this.UnprocessableEntity() as IActionResult;
        }

        [HttpPut]
        [Route("move/{id}")]
        public async Task<IActionResult> UpdateTable(string id, UpdateTodoTaskTableDto todoTask)
        {
            var table = await tableService.GetByIdAsync(todoTask.TableId);
            var task = await todoTaskService.GetByIdAsync(id);

            if (table == null || task == null)
            {
                return this.NotFound();
            }

            var response = await todoTaskService.UpdateTableAsync(id, todoTask.TableId);
            
            return response  ? this.NoContent() : this.UnprocessableEntity() as IActionResult;
        }
    }
}
