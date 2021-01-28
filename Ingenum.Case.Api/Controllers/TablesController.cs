namespace Ingenum.Case.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ingenum.Case.Core.Services;
    using Ingenum.Case.Model.DTO;
    using Microsoft.AspNetCore.Mvc;

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

        public async Task<ActionResult<TableDto>> Get(string id)
        {
            var table = await tableService.GetByIdAsync(id);

            if (table == null)
            {
                return this.NotFound(id);
            }

            return this.Ok(table);
        }
    }
}
