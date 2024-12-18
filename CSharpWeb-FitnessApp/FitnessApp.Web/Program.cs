using FitnessApp.Data;
using FitnessApp.Data.Seeding;
using FitnessApp.Services.Data;
using FitnessApp.Services.Data.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Connect to the database
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // They are left so that it is easier to register a new user for testing purposes
        // (in a production environment, it is good to have the password as secure as possible)
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        // Configure security settings
        builder.Services.AddControllersWithViews(cfg =>
        {
            cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

        builder.Services.AddRazorPages();

        // Register custom services
        builder.Services.AddScoped<ISpaProcedureService, SpaProcedureService>();
        builder.Services.AddScoped<IFitnessEventService, FitnessEventService>();
        builder.Services.AddScoped<IClassService, ClassService>();
        builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();
        builder.Services.AddScoped<IInstructorService, InstructorService>();
        builder.Services.AddScoped<IUserService, UserService>();

        WebApplication app = builder.Build();

        // Seed roles and assign admin role
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            RolesSeeder.SeedRoles(services);
            RolesSeeder.AssignAdminRole(services);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // Who am I?
        app.UseAuthorization(); // What can I do?

        // Configure status code pages
        app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

        // Configure routes
        app.MapControllerRoute(
            name: "Areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "Errors",
            pattern: "{controller=Home}/{action=Index}/{statusCode?}");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}