namespace Ingenum.Case.Model.DTO
{
    using System;

    public class TodoTaskDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string TableId { get; set; }
    }
}
