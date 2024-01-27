
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using ToDo.Application;
using ToDo.Infrastructure.Extensions;

namespace ToDo.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices();

           
            var app = builder.Build();

            Configure();
           

            app.Run();

            void ConfigureServices()
            {
                builder.Services.AddApplicationServices();
                builder.Services.AddRepositoriesConfigure(builder.Configuration);
                builder.Services.AddControllers();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo.API", Version = "v1" });
                });
            }



           void Configure()
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo.API v1"));
                }

                app.UseHttpsRedirection();

                app.UseRouting();


                app.UseAuthorization();

                app.MapControllers();

                app.AddRepositoreyData();
            }
        }


      
    }
}
