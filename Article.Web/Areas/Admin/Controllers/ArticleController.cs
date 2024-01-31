using Article.Entity.DTOs.Articles;
using Article.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;

        public ArticleController(IArticleService articleService,ICategoryService categoryService)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
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
    }
}
