namespace Ingenum.Case.Core.Services
{
    using System;
    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Model.Database;
    using Ingenum.Case.Model.DTO;

    public interface ITableService : IBaseService<TableDto, AddTableDto, Table, ITableRepository>
    {
    }
}
