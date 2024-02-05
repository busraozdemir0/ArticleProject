using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User); // giris yapan kullaniciyi bul
            var map = mapper.Map<UserDto>(loggedInUser); // bu giris yapan kullaniciyi UserDto ile maple yani UserDto'ya donustur

            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));   // gris yapan kullanicin rolunu bul                                                                //bu separator roller arasina koyacagi karakteri ifade eder
            map.Role = role; // bulunan rolu map'deki Role degiskenine ata

            return View(map);
        }
    }
}
