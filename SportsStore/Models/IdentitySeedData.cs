using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            AppIdentityDbContext context = serviceProvider.GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByNameAsync(AdminUser);

            if (user is null)
            {
                user = new IdentityUser("Admin")
                {
                    Email = "admin@example.com",
                    PhoneNumber = "555-1234",
                };

                await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}
