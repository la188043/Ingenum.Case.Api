namespace Ingenum.Case.Model.Database
{
    using System.Collections.Generic;

    public class Table : Entity
    {
        public string Name { get; set; }

        public IList<TodoTask> Tasks { get; }

        public Table()
        {
            this.Tasks = new List<TodoTask>();
        }

        public void AddTask(TodoTask task)
        {
            if (!this.Tasks.Contains(task))
            {
                this.Tasks.Add(task);
            }
        }
    }
}
