using TaskManagementAPI.Services;
using TaskManagementAPI.Models;
using Serilog;
using Microsoft.EntityFrameworkCore;


namespace TaskManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<TaskManagementServices>();
            builder.Services.AddDbContext<TaskManagementContext>();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var logger = new LoggerConfiguration()
            .WriteTo.File("C:/Users/pulkit/source/repos/TaskManagementAPI/TaskManagementLog/", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            builder.Services.AddSerilog(logger);

            builder.Services.AddCors(o => o.AddPolicy("myPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors();

            app.MapControllers();
           

            app.Run();
        }
    }
}