using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EPOSDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("identity")));
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.Run();
