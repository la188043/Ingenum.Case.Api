using Ingenum.Case.Core.Repository;
using Ingenum.Case.Model.Database;

namespace Ingenum.Case.EntityFramework.Repository
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(ApiContext context) : base(context)
        {
        }
    }
}
