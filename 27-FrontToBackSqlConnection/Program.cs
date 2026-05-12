using _27_FrontToBackSqlConnection.Data;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            //builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer("Server=ACER\\MSSQLSERVER01;Database=Pronia;Trusted_Connection=true;TrustServerCertificate=true"));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
