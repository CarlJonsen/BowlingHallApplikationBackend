
using DatabaseModule.Models;
using MatchAPI.Repository;
using MatchAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace Swagger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BowlingDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Lägg till AccountRepo som Scoped Service
            builder.Services.AddScoped<AccountRepo>();
            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<BookingRepo>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<MatchRepo>();
            builder.Services.AddScoped<MatchService>();

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


            app.MapControllers();

            app.Run();
        }
    }
}
