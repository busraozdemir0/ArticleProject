using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map) // maplenmis user'lar uzerinde gez
            {
                var findUser=await userManager.FindByIdAsync(item.Id.ToString());  // user'in id'sini bul
                var role = string.Join("",await userManager.GetRolesAsync(findUser));  // kullanicinin rolünü bul
                                     //bu separator roller arasina koyacagi karakteri ifade eder
                item.Role = role;
            }

            return View(map);
        }
    }
}
