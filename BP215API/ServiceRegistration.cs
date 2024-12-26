using BP215API.Exceptions;
using BP215API.Services.Abstracts;
using BP215API.Services.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

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
        public static IApplicationBuilder UseBp215ApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
               opt =>
               {
                   opt.Run(async context =>
                   {
                       var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                       var exception = feature.Error;
                       if (exception is IBaseException bEx)
                       {
                           context.Response.StatusCode = bEx.StatusCode;
                           await context.Response.WriteAsJsonAsync(new
                           {
                               Message = bEx.ErrorMessage
                           });
                       }
                       else
                       {
                           context.Response.StatusCode = 400;
                           await context.Response.WriteAsJsonAsync(new
                           {
                               Message = "Gözlənilməz xəta baş verdi"
                           });
                       }
                   });
               });
            return app;
        }
    }
    
}
