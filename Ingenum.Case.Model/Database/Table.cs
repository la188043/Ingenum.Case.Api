namespace Ingenum.Case.Model.Database
{
    using System.Collections.Generic;

    public class Table : Entity
    {
        public string Name { get; set; }

        public virtual IEnumerable<TodoTask> Tasks { get; }
    }
}
