using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService,ICategoryService categoryService,IMapper mapper)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
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
            return View(new ArticleAddDto { Categories=categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            await articleService.CreateArticleAsync(articleAddDto);
            RedirectToAction("Index", "Home", new { Area = "Admin" });

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId); // id'ye göre makaleyi getir
            
            var categories=await categoryService.GetAllCategoriesNonDeleted(); // tum kategorileri getir

            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article); // id'ye gore gelen makaleyi map'le
            articleUpdateDto.Categories = categories; // map'lenen makaledeki Categories listesine tum kategorileri iceren categories degiskenini ata

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            await articleService.UpdateArticleAsync(articleUpdateDto);

            var categories = await categoryService.GetAllCategoriesNonDeleted(); // tum kategorileri getir
            articleUpdateDto.Categories = categories; // map'lenen makaledeki Categories listesine tum kategorileri iceren categories degiskenini ata

            return View(articleUpdateDto);
        }

    }
}
