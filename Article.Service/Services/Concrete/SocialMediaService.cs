using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.SocialMedias;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<SocialMediaDto>> GetAllSocialMedia()
        {
            var socialMedia = await unitOfWork.GetRepository<SocialMedia>().GetAllAsync();

            var map=mapper.Map<List<SocialMediaDto>>(socialMedia);

            return map;

        }

        public async Task<SocialMedia> GetSocialMediaById(int id)
        {
            var socialMedia = await unitOfWork.GetRepository<SocialMedia>().GetAsync(x=>x.Id==id);

            return socialMedia;
        }

        public async Task UpdateSocialMedia(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var socialMedia = await unitOfWork.GetRepository<SocialMedia>().GetAsync(x=>x.Id == socialMediaUpdateDto.Id);

            socialMedia.GmailUrl = socialMediaUpdateDto.GmailUrl;
            socialMedia.GithubUrl=socialMediaUpdateDto.GithubUrl;
            socialMedia.TwitterUrl=socialMediaUpdateDto.TwitterUrl;
            socialMedia.LinkedinUrl=socialMediaUpdateDto.LinkedinUrl;
            socialMedia.InstagramUrl=socialMediaUpdateDto.InstagramUrl;

            await unitOfWork.GetRepository<SocialMedia>().UpdateAsync(socialMedia);
            await unitOfWork.SaveAsync();

        }
    }
}
