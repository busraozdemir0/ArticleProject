using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using Article.Service.Extensions;
using Article.Service.Services.Abstractions;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Articlee> validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Articlee> validator)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // View tarafinda kategorileri acilir menude listelemek icin

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Articlee>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId); // id'ye göre makaleyi getir

            var categories = await categoryService.GetAllCategoriesNonDeleted(); // tum kategorileri getir

            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article); // id'ye gore gelen makaleyi map'le
            articleUpdateDto.Categories = categories; // map'lenen makaledeki Categories listesine tum kategorileri iceren categories degiskenini ata

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var map = mapper.Map<Articlee>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.UpdateArticleAsync(articleUpdateDto);

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategoriesNonDeleted(); // tum kategorileri getir
            articleUpdateDto.Categories = categories; // map'lenen makaledeki Categories listesine tum kategorileri iceren categories degiskenini ata

            return View(articleUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid articleId)
        {
            await articleService.SafeDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

    }
}
