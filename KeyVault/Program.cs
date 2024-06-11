using KeyVault.Controllers;
using KeyVault.IServices;
using KeyVault.Middleware;
using KeyVault.Services;

namespace KeyVault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddScoped<ICreateSecretService, CreateSecretService>();
            builder.Services.AddScoped<IGetSecretService, GetSecretService>();
            builder.Services.AddScoped<IDeleteSecretService, DeleteSecretService>();
            builder.Services.AddScoped<IPurgeSecretService, PurgeSecretService>();

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
