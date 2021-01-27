namespace Ingenum.Case.EntityFramework.Repository
{
    using System;
    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Model.Database;

    public class TodoTaskRepository : BaseRepository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(ApiContext context) : base(context)
        {
        }
    }
}
