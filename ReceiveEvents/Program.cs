using ReceiveEvents.Controllers;
using ReceiveEvents.IServices;
using ReceiveEvents.Middleware;
using ReceiveEvents.Services;

namespace ReceiveEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IEventProcessingService, EventProcessingService>();
            builder.Services.AddScoped<IEventSendingService, EventSendingService>();

            builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();

            // Load secrets from Azure Key Vault
            var keyVaultUri = new Uri(builder.Configuration["VaultName"]);
            var keyVaultService = new KeyVaultService(keyVaultUri);
            var secretConfigurations = keyVaultService.GetSecretConfigurationsAsync().GetAwaiter().GetResult();

            builder.Services.AddSingleton(secretConfigurations);

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
