
using BP215API.DAL;
using BP215API.Services.Abstracts;
using BP215API.Services.Implements;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BP215API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            builder.Services.AddDbContext<BP215APIDbContext>(s => s.UseSqlServer(builder.Configuration.GetConnectionString  ("MSSql")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddFluentValidationAutoValidation();
            //builder.Services.AddFluentValidation(x => {
            //    x.RegisterValidatorsFromAssemblyContaining<Program>();
            // });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ILanguageService, LanguageService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
