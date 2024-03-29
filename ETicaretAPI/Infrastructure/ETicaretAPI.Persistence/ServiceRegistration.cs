
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration //katmanlar arasında bir şekilde bir şeyi göndermek için kullanılır.
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");

            //AddScoped için:
            //services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString("PostreSQL"))); //Persistence/sağ tık/ NuGet/ Npgsql.EntityFrameworkCore.PostgreSQL

            //AddSingleton için:
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString("PostreSQL")), ServiceLifetime.Singleton);


            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
        }
    }
}
