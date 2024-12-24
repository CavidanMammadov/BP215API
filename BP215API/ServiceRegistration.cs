using BP215API.Services.Abstracts;
using BP215API.Services.Implements;

namespace BP215API
{
    public  static class ServiceRegistration
    {
        public static IServiceCollection  AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }
}
