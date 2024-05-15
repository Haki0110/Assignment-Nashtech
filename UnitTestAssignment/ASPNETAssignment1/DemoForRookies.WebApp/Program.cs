using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.Models.Repository;
using OfficeOpenXml;

namespace ASPNETAssignment1.WebApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.services.Addscoped<IUserRepo, UserRepo>(); đăng kí cả Repo và Service
            builder.Services.AddSingleton<IPersonRepositories, PersonRepository>();
            builder.Services.AddSingleton<PersonBusinessLogic, PersonBusinessLogic>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
    name: "NashTech",
    pattern: "{area:exists}/{controller}/{action=Index}/{id?}"
);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
