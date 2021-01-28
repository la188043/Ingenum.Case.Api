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

        public TodoTasksController(ITodoTaskService todoTaskService)
        {
            this.todoTaskService = todoTaskService;
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
    }
}
