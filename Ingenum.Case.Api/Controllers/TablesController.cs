namespace Ingenum.Case.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Ingenum.Case.Core.Services;
    using Ingenum.Case.Model.DTO;

    [Route("tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService tableService;

        public TablesController(ITableService tableService)
        {
            this.tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> Get()
        {
            var tables = await tableService.GetAllAsync();

            return this.Ok(tables);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TableDto>> Get(string id)
        {
            var table = await tableService.GetByIdAsync(id);

            if (table == null)
            {
                return this.NotFound(id);
            }

            return this.Ok(table);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(string id, TableDto newTable)
        {
            var todoTask = await this.tableService.GetByIdAsync(id);

            if (todoTask == null)
            {
                return this.NotFound(id);
            }

            if (newTable == null)
            {
                return this.ValidationProblem();
            }

            var updatedTodoTask = await this.tableService.UpdateAsync(id, newTable);

            return updatedTodoTask != null ? this.NoContent() : this.UnprocessableEntity() as IActionResult;
        }
    }
}
