
using Application.Interfaces.UnitOfWork;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Registration
    {

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();



        }




    }
}
