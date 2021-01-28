using System;
namespace Ingenum.Case.Model.DTO
{
    public class AddTodoTaskDto
    {
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string TableId { get; set; }
    }
}
