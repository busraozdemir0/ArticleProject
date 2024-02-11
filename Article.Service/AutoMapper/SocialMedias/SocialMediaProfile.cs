using Article.Entity.DTOs.SocialMedias;
using Article.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.AutoMapper.SocialMedias
{
    public class SocialMediaProfile:Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
        }
    }
}
