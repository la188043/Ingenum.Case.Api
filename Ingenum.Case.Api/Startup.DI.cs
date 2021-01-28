namespace Ingenum.Case.Api
{
    using Microsoft.Extensions.DependencyInjection;

    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Core.Services;
    using Ingenum.Case.EntityFramework.Repository;
    using Ingenum.Case.Infrastructure.Services;

    public partial class Startup
    {
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            // --  Models --

            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ITableService, TableService>();

            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<ITodoTaskService, TodoTaskService>();
        }
    }
}
