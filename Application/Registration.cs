
using System.Reflection;
using Application.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class Registration
    {

        public static void AddApplication(this IServiceCollection services) {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());


        }



    }
}
