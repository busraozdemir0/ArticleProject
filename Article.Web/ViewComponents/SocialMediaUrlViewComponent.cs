using Article.Entity.DTOs.SocialMedias;
using Article.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.ViewComponents
{
    public class SocialMediaUrlViewComponent:ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IMapper mapper;

        public SocialMediaUrlViewComponent(ISocialMediaService socialMediaService,IMapper mapper)
        {
            this.socialMediaService = socialMediaService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMedia = await socialMediaService.GetSocialMediaById(1);
            var map = mapper.Map<SocialMediaDto>(socialMedia);
            return View(map);
        }
    }
}
