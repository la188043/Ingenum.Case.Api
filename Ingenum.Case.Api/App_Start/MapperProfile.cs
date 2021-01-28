using Ingenum.Case.Model.Database;
using Ingenum.Case.Model.DTO;

namespace Ingenum.Case.Api.App_Start
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            // Table Mapping
            this.CreateMap<Table, TableDto>()
                .ReverseMap();

            this.CreateMap<Table, AddTableDto>()
                .ReverseMap();

            this.CreateMap<Table, UpdateTableDto>()
                .ReverseMap();

            // TodoTask Mapping
            this.CreateMap<TodoTask, TodoTaskDto>()
                .ReverseMap();

            this.CreateMap<TodoTask, AddTodoTaskDto>()
                .ReverseMap();

            this.CreateMap<TodoTask, UpdateTableDto>()
                .ReverseMap();
        }
    }
}
