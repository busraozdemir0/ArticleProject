using Article.Entity.DTOs.Articles;
using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using Article.Service.Extensions;
using Article.Web.ResultMessages;
using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IToastNotification toast, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.validator = validator;
            this.toast = toast;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map) // maplenmis user'lar uzerinde gez
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());  // user'in id'sini bul
                var role = string.Join("", await userManager.GetRolesAsync(findUser));  // kullanicinin rolünü bul
                                                                                        //bu separator roller arasina koyacagi karakteri ifade eder
                item.Role = role;
            }

            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync(); // tum rolleri bul
            return View(new UserAddDto { Roles = roles }); // bulunan rolleri dto icerisindeki rollere esitleyerek view'a gonder
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync(); // tum rolleri al

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email; // proje senaryomuzda email ile kullanici adi ayni olacagi icin bastan esitliyoruz.
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password); // Null hatasindan dolayi; Sifre eger bossa "" bunu gonderecek. Bos degilse o password'u gonderecek
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());

                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);

                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString()); // dto'daki id'den kullaniyi bul

            if (user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user)); // bulunan kullanicinin rolunu cek
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user); //** asagidaki yorum satirindaki kisimlar bu satir ile otomatik yapilmis olacaktir
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        //user.FirstName = userUpdateDto.FirstName;
                        //user.LastName = userUpdateDto.LastName;
                        //user.Email = userUpdateDto.Email;
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();

                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await userManager.RemoveFromRoleAsync(user, userRole); // oncelikle kullanici uzerinde yer alan rolu kaldiriyoruz
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString()); // selectlist'den secilen rolun id'sine gore rolu bul
                            await userManager.AddToRoleAsync(user, findRole.Name); // bulunan rolu guncellenecek olan kullaniciya ata
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });

                    }
                }
            }

            return NotFound(); // user'ı bulamazsa NotFound donecek
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);  // Identity'nin ondelete metodlarında eger bir kullanici silinirse kullaniciya bagli olan roller de silinir.+
                                                               // Bu yüzden ayriyetten rol silme silemi yapmamiza gerek kalmaz.

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
    }
}
