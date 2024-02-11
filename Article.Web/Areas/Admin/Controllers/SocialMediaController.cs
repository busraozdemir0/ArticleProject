using Article.Entity.DTOs.SocialMedias;
using Article.Entity.Entities;
using Article.Service.Extensions;
using Article.Service.Services.Abstractions;
using Article.Web.Consts;
using Article.Web.ResultMessages;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IMapper mapper;
        private readonly IValidator<SocialMedia> validator;
        private readonly IToastNotification toast;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper, IValidator<SocialMedia> validator, IToastNotification toast)
        {
            this.socialMediaService = socialMediaService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Index()
        {
            var socialMedia = await socialMediaService.GetAllSocialMedia();
            return View(socialMedia);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var socialMedia=await socialMediaService.GetSocialMediaById(id);
            var map = mapper.Map<SocialMediaUpdateDto>(socialMedia);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var map = mapper.Map<SocialMedia>(socialMediaUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await socialMediaService.UpdateSocialMedia(socialMediaUpdateDto);
                toast.AddSuccessToastMessage("Sosyal medya yönetim linkleri başarıyla güncellendi", new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "SocialMedia", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
    }
}
