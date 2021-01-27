namespace Ingenum.Case.Model.DTO
{
    using System.Collections.Generic;

    public class TableDto
    {
        public string Name { get; set; }

        public IEnumerable<TodoTaskDto> Tasks { get; set; }
    }
}
