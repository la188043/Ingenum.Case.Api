namespace Ingenum.Case.Api.App_Start
{
    using Ingenum.Case.Model.Database;
    using Ingenum.Case.Model.DTO;

    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            // Table Mapping
            this.CreateMap<Table, TableDto>()
                .ReverseMap();

            this.CreateMap<Table, AddTableDto>()
                .ReverseMap();

            // TodoTask Mapping
            this.CreateMap<TodoTask, TodoTaskDto>()
                .ReverseMap();

            this.CreateMap<TodoTask, AddTodoTaskDto>()
                .ReverseMap();
        }
    }
}
