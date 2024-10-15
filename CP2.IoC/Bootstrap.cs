using CP2.Application.Services;
using CP2.Data.AppData;
using CP2.Data.Repositories;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace CP2.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });


            // Use AddScoped to maintain a single instance per request
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();

            services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>();
            services.AddScoped<IVendedorApplicationService, VendedorApplicationService>();
        }
    }
}
