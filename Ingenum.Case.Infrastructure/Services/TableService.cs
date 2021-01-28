namespace Ingenum.Case.Infrastructure.Services
{
    using AutoMapper;

    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Core.Services;
    using Ingenum.Case.Model.Database;
    using Ingenum.Case.Model.DTO;

    public class TableService : BaseService<TableDto, AddTableDto, Table, ITableRepository>, ITableService
    {
        public TableService(ITableRepository tableRepository, IMapper mapper) : base(tableRepository, mapper)
        {
        }
    }
}
