using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingenum.Case.Core.Repository;
using Ingenum.Case.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace Ingenum.Case.EntityFramework.Repository
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(ApiContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await this.context.Tables
                .Include(x => x.Tasks.Select(task => !task.IsDeleted))
                .ToListAsync();
        }

        public override async Task<Table> GetByIdAsync(string id)
        {
            return await this.context.Tables
                .Include(x => x.Tasks.Select(y => !y.IsDeleted))
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
