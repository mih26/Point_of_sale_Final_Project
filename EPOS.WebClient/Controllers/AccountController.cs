using EPOS.BlazorClient.Shared.Models.Identity;
using EPOS.BlazorClient.Shared.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.WebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext db;
        public AccountController(AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username,
                           model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var appUser = await db.Users.FirstAsync(x=> x.UserName == model.Username);
                    appUser.CounterId = model.CounterId;
                    await db.SaveChangesAsync();
                    return LocalRedirect("~/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    
                }
            }
            return View(model);
        }
    }
}
