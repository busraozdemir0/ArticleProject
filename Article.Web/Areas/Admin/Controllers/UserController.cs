using Article.Entity.DTOs.Articles;
using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using Article.Web.ResultMessages;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IToastNotification toast, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.toast = toast;
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
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync(); // tum rolleri bul
            return View(new UserAddDto { Roles=roles}); // bulunan rolleri dto icerisindeki rollere esitleyerek view'a gonder
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var roles = await roleManager.Roles.ToListAsync(); // tum rolleri al

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email; // proje senaryomuzda email ile kullanici adi ayni olacagi icin bastan esitliyoruz.
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password); // Null hatasindan dolayi; Sifre eger bossa "" bunu gonderecek. Bos degilse o password'u gonderecek
                if(result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                   
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı!" }); 
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                        ModelState.AddModelError("", errors.Description);

                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });

        }
    }
}
