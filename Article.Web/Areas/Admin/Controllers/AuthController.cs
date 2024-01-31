using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous] // bu metodun yetkisiz olmasi icin
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if(result.Succeeded) // giris basariliysa
                    {
                        return RedirectToAction("Index","Home",new {Area="Admin"});
                    }
                    else // giris basarili degilse mesaj dondurecek bir error ekliyoruz
                    {
                        ModelState.AddModelError("", "E-Posta veya şifreniz yanlıştır.");
                        return View(); // tekrar Login'i getir
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-Posta veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [Authorize]  // * cikis yapabilmek icin o kisinin giris yapmis olmasi gerekiyor 
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {Area=""}); // Default home'a yonlenmesi icin Area icini bos biraktik
        }
    }
}
