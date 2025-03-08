using Microsoft.EntityFrameworkCore;
using VerstaMain.Data;
using VerstaMain.Mapping;
using VerstaMain.Services;

namespace VerstaMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                //options.UseMySQL(builder.Configuration.GetConnectionString("MySQL"), sql => { });
                options.UseInMemoryDatabase("inmemoryversta");
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapControllers();
            app.UseRouting();

            app.Run();
        }
    }
}
