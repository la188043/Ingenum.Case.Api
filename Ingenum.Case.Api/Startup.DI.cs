
namespace Ingenum.Case.Api
{
    using Ingenum.Case.Core.Repository;
    using Ingenum.Case.Core.Services;
    using Ingenum.Case.EntityFramework.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            // --  Models --

            services.AddScoped<ITableRepository, TableRepository>();

            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
        }
    }
}
