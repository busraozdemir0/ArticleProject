using Article.Entity.DTOs.SocialMedias;
using Article.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Abstractions
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaDto>> GetAllSocialMedia();
        Task<SocialMedia> GetSocialMediaById(int id);
        Task UpdateSocialMedia(SocialMediaUpdateDto socialMediaUpdateDto);
    }
}
