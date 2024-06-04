
using BookTaxi.Middleware;
using BookTaxi.Models;
using BookTaxi.Services;
using BookTaxi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookTaxi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EF_DataContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
            );

            builder.Services.AddScoped<IRiderDetailsService, RiderDetailsService>();

            builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();



            app.MapControllers();

            app.Run();
        }
    }
}
