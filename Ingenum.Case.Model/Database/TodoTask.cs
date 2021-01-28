namespace Ingenum.Case.Model.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TodoTask : Entity
    {
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Table))]
        public string TableId { get; set; }
    }
}
