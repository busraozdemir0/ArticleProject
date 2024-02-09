using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using Article.Service.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Article.Web.ResultMessages.Messages;

namespace Article.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User); // giris yapan kullaniciyi bul
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == loggedInUser.Id, x => x.Image); // giris yapan kullanicinin gorseli

            var map = mapper.Map<UserDto>(loggedInUser); // bu giris yapan kullaniciyi UserDto ile maple yani UserDto'ya donustur

            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));   // gris yapan kullanicin rolunu bul   
            map.Role = role; // bulunan rolu map'deki Role degiskenine ata

            map.Image.FileName = getUserWithImage.Image.FileName; // giris yapan kullanicinin gorselini map'deki FileName'e ata

            return View(map);
        }
    }
}
