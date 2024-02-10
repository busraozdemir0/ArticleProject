using Article.Entity.DTOs.Roles;
using Article.Entity.Entities;
using Article.Web.Consts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;

        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();

            var mapRoles = mapper.Map<List<RoleDto>>(roles);

            return View(mapRoles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Add(RoleAddDto roleAddDto)
        {
            var map = mapper.Map<AppRole>(roleAddDto);
            map.ConcurrencyStamp = Guid.NewGuid().ToString(); // ayni anda iki farkli islem yapiliyorsa bunlarin cakismasini engeller (ayni anda ayni verinin guncellenme islemi gibi)

            var result = await roleManager.CreateAsync(map);

            if (result.Succeeded)
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            else
                return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            var map = mapper.Map<RoleUpdateDto>(role);

            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Update(RoleUpdateDto roleUpdateDto)
        {
            var role = await roleManager.FindByIdAsync(roleUpdateDto.Id.ToString());

            if (role != null)
            {
                role.Id = roleUpdateDto.Id;
                role.Name= roleUpdateDto.Name;
                role.NormalizedName=roleUpdateDto.NormalizedName;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Role", new { Area = "Admin" });
                else
                    return NotFound();
            }
            return NotFound();
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            
            var result=await roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            else
                return NotFound();
        }
    }
}
