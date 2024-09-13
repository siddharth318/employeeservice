using EmployeeService.Extentions;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EmployeeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();



            //builder.Services.AddScoped<EmployeeService.Services.EmployeeService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService.Services.EmployeeService>();
            builder.Services.AddDbContext<EmployeeContext>(
                (option) => option.UseSqlServer(builder.Configuration.GetConnectionString("employeess")));
            builder.Services.AddConsulConfig(builder.Configuration);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //logging

            var log = new LoggerConfiguration()
                .WriteTo.File(@"C:/Users/pulkit/Desktop/Assignments/mydo_services/EmployeeService/EmployeeLog/userLog.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Services.AddSerilog(log);

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