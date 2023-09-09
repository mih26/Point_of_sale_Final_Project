using EPOS.BlazorClient.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace EPOS.BlazorClient.Server.HostedServices
{
    public class IdentityDbInitializer
    {
        //private readonly ApplicationDbContext db;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IdentityDbInitializer(/*ApplicationDbContext db,*/ UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedAsync()
        {


            await CreateRoleAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            await CreateRoleAsync(new IdentityRole { Name = "Staff", NormalizedName = "STAFF" });
            await CreateRoleAsync(new IdentityRole { Name = "SalesOperator", NormalizedName = "SALESOPERATOR" });

            var hasher = new PasswordHasher<AppUser>();
            var user = new AppUser { UserName = "admin", NormalizedUserName = "ADMIN" };
            user.PasswordHash = hasher.HashPassword(user, "@Open1234");
            await CreateUserAsync(user, "Admin");


            user = new AppUser { UserName = "r50", NormalizedUserName = "R50" };
            user.PasswordHash = hasher.HashPassword(user, "@Open1234");
            await CreateUserAsync(user, "Staff");

            user = new AppUser { UserName = "operator1", NormalizedUserName = "OPERATOR1", CounterId=1 };
            user.PasswordHash = hasher.HashPassword(user, "@Open1234");
            await CreateUserAsync(user, "SalesOperator");

        }
        private async Task CreateRoleAsync(IdentityRole role)
        {
            var exits = await roleManager.RoleExistsAsync(role.Name ?? "");
            if (!exits)
                await roleManager.CreateAsync(role);
        }
        private async Task CreateUserAsync(AppUser user, string role)
        {
            var exists = await userManager.FindByNameAsync(user.UserName ?? "");
            if (exists == null)
            {
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, role);
            }

        }
    }
}
