using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.Articles;
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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<ArticleDto>> GetAllArticleAsync()
        {
            var articles=await unitOfWork.GetRepository<Articlee>().GetAllAsync();
           
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;

        }
    }
}
