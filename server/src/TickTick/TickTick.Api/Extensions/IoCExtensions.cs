using TickTick.Api.Services;

namespace TickTick.Api
{
    // extension methods zijn altijd static
    public static class IoCExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonsService, PersonsService>();
        }
    }
}
