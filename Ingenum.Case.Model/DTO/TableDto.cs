namespace Ingenum.Case.Model.DTO
{
    using System.Collections.Generic;

    public class TableDto
    {
        public IEnumerable<TodoTaskDto> Tasks { get; set; }
    }
}
