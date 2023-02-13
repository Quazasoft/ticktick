using MediatR;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Repositories;
using TickTick.Repositories.Base;

namespace TickTick.Api
{
    // extension methods zijn altijd static
    public static class IoCExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();

            services.AddMediatR(System.Reflection.Assembly.GetAssembly(typeof(IoCExtensions)));
        }
    }
}
