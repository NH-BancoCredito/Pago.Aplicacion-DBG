using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pago.CrossCutting.Configs;
using Pago.Domain.Repositories;
using Pago.Infraestructure.Repositories.Base;
using System.Reflection;


namespace Pago.Infraestructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfiguration = new AppConfiguration(configuration);

            var connectionString = appConfiguration.ConexionDBPagos;

            services.AddDbContext<PagoDbContext>(
                options  =>
                {
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging();
                }
            );

            services.AddRepositories(Assembly.GetExecutingAssembly());
           
        }

        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            var respositoryTypes = assembly
                .GetExportedTypes().Where(item => item.GetInterface(nameof(IRepository)) != null).ToList();


            foreach (var repositoryType in respositoryTypes)
            {
                var repositoryInterfaceType = repositoryType.GetInterfaces()
                    .Where(item => item.GetInterface(nameof(IRepository)) != null)
                    .First();

                services.AddScoped(repositoryInterfaceType, repositoryType);
            }
        }
    }
}
