using Article.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Article.Web.ViewComponents
{
    public class HomeArticlesViewComponent:ViewComponent
    {
        private readonly IArticleService _articleService;
        public HomeArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllArticlesMostViewedAsync();
            return View(articles);
        }
    }
}
