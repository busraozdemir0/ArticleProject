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

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = Guid.Parse("324BDFDE-4DDB-4333-9ED1-1E9E91226A73");
            var imageId = Guid.Parse("25A68467-8A27-45B7-9202-50241CEA50FC");

            var article = new Articlee(articleAddDto.Title, articleAddDto.Content, userId,articleAddDto.CategoryId, imageId);

            await unitOfWork.GetRepository<Articlee>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()  // Tum makaleleleri kategorleriyle birlikte silinmemis olanlari getir
        {
            // Kategorileri makalelere include ettik
            var articles=await unitOfWork.GetRepository<Articlee>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category); // (x.IsDeleted==False) IsDeleted'leri false olanlari getir 

            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;

        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId) 
        {
            // Kategorileri makalelere include ettik
            var article = await unitOfWork.GetRepository<Articlee>().GetAsync(x => !x.IsDeleted && x.Id==articleId, x => x.Category); // (x.IsDeleted==False) IsDeleted'leri false olanlari getir 

            var map = mapper.Map<ArticleDto>(article);

            return map;

        }

        public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitOfWork.GetRepository<Articlee>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
           
            article.Title= articleUpdateDto.Title;
            article.Content= articleUpdateDto.Content;
            article.CategoryId= articleUpdateDto.CategoryId;

            await unitOfWork.GetRepository<Articlee>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Articlee>().GetByGuidAsync(articleId);

            article.IsDeleted = true; // makaleyi silmek yerine IsDeleted (silindi mi) alanini true olarak guncelliyoruz. (silinmediyse false degerine sahip)
            article.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Articlee>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }
    }
}
