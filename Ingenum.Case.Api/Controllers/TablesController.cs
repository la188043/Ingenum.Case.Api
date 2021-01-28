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
    }
}
