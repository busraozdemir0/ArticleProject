using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.AutoMapper.Articles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Articlee>().ReverseMap(); // *** Dto istersem Articlee ile maple'me islemi yap, eger Articlee istersem dto'yu map'le.
            CreateMap<ArticleUpdateDto, Articlee>().ReverseMap(); // *** Dto istersem Articlee ile maple'me islemi yap, eger Articlee istersem dto'yu map'le.
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap(); // *** Dto istersem Articlee ile maple'me islemi yap, eger Articlee istersem dto'yu map'le.
        }
    }
}
