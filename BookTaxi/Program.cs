
using BookTaxi.IServices;
using BookTaxi.Middleware;
using BookTaxi.Models;
using BookTaxi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddScoped<IDriverDetailsService, DriverDetailsService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IRequestRideService, RequestRideService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IDriverAvailibiltyService, DriverAvailibilityService>();
            builder.Services.AddScoped<ICurrentRideService, CurrentRideService>();
            builder.Services.AddScoped<IStartRideService, StartRideService>();
            builder.Services.AddScoped<IEndRideService, EndRideService>();
            builder.Services.AddScoped<ICancleRideService, CancleRideService>();
            builder.Services.AddScoped<IRatingService, RatingService>();


            builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .   AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();



            app.MapControllers();

            app.Run();
        }
    }
}
