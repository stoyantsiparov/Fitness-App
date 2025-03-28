using FitnessApp.Services.Data.Contracts;
using FitnessApp.Services.Data;
using FitnessApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            string? fitnessWebAppOrigin = builder.Configuration.GetValue<string>("ClientOrigins:FitnessWebApp");

            // Add services to the container.
            builder.Services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(cfg =>
            {
                cfg.AddPolicy("AllowAll", policyBld =>
                {
                    policyBld
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });

                if (!String.IsNullOrWhiteSpace(fitnessWebAppOrigin))
                {
                    cfg.AddPolicy("AllowMyServer", policyBld =>
                    {
                        policyBld
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins(fitnessWebAppOrigin);
                    });
                }
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IFitnessEventService, FitnessEventService>();
            builder.Services.AddScoped<ISpaProcedureService, SpaProcedureService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();
            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            if (!String.IsNullOrWhiteSpace(fitnessWebAppOrigin))
            {
                app.UseCors("AllowMyServer");
            }

            app.MapControllers();

            app.Run();
        }
    }
}