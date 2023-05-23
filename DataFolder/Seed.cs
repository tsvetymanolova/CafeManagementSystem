using Microsoft.Extensions.DependencyInjection;
namespace CafeManagementSystemProject.DataFolder
{
    public class Seed
    {
        public static void SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<MVCOrderDbContext>();
        }
    }
}
