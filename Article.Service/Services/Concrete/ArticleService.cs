﻿using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using Article.Entity.Enums;
using Article.Service.Extensions;
using Article.Service.Helpers.Images;
using Article.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            // var userId = Guid.Parse("324BDFDE-4DDB-4333-9ED1-1E9E91226A73");

            var userId = _user.GetLoggedInUserId();  // login olan kullanicinin id'si
            var userEmail = _user.GetLoggedInUserEmail();

            var imageUpload = await imageHelper.Upload(articleAddDto.Title,articleAddDto.Photo,ImageType.Post);
            Image image = new(imageUpload.FullName,articleAddDto.Photo.ContentType,userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Articlee(articleAddDto.Title, articleAddDto.Content, userId,userEmail,articleAddDto.CategoryId, image.Id);

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
            var article = await unitOfWork.GetRepository<Articlee>().GetAsync(x => !x.IsDeleted && x.Id==articleId, x => x.Category,i=>i.Image); // (x.IsDeleted==False) IsDeleted'leri false olanlari getir 

            var map = mapper.Map<ArticleDto>(article);

            return map;

        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await unitOfWork.GetRepository<Articlee>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
            var userEmail = _user.GetLoggedInUserEmail();

            if (articleUpdateDto.Photo != null) // articleUpdateDto'daki Photo null degilse yani bir resim secmisse
            {
                imageHelper.Delete(article.Image.FileName); // once makalede var olan resmi silecek

                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post); // daha sonrasinda yeni resim yukleme islemleri yapilacak
                Image image = new(imageUpload.FullName,articleUpdateDto.Photo.ContentType,userEmail);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id; // makalenin resimId'sini yeni yukledigimiz resim Id'si ile degistiriyoruz
            }

            article.Title= articleUpdateDto.Title;
            article.Content= articleUpdateDto.Content;
            article.CategoryId= articleUpdateDto.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Articlee>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Articlee>().GetByGuidAsync(articleId);
            var userEmail = _user.GetLoggedInUserEmail();

            article.IsDeleted = true; // makaleyi silmek yerine IsDeleted (silindi mi) alanini true olarak guncelliyoruz. (silinmediyse false degerine sahip)
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail; 

            await unitOfWork.GetRepository<Articlee>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }
    }
}
