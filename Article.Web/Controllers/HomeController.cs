using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
using Article.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Article.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor httpContextAccessor,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage=1, int pageSize=3, bool isAscending=false)
        {
            var articles = await articleService.GetAllByPagingAsync(categoryId,currentPage,pageSize,isAscending);
            return View(articles);  
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            // Giren her farklı kullanici makalenin Devamını Oku secenegine tikladiginda makalenin okunma/gorunme sayisini bir artiracagiz

            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articleVisitors = await unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x=>x.Visitor, y=>y.Article); // ArticleVisitor tablosundaki bilgileri getir dedik ve getir derken Article ve Visitor tablosunu ArticleVisitor tablosuna include ettik
            var article = await unitOfWork.GetRepository<Articlee>().GetAsync(x => x.Id == id);

            var result=await articleService.GetArticleWithCategoryNonDeletedAsync(id);

            var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x=>x.IpAddress==ipAddress);

            var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id); // Kullanicinin tikladigi makale ve kullanicinin bilgileri eklenecek olan degerler
            
            if(articleVisitors.Any(x=>x.VisitorId==addArticleVisitors.VisitorId && x.ArticleId==addArticleVisitors.ArticleId)) // eger ayni kullanici ayni makaleye tekrar tiklamissa ViewCount artmayacak
                return View(result);
            
            else 
            {
                await unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors); // ArticleVisitor tablosuna kayit ekleme
                article.ViewCount += 1; // tiklanan makalenin ViewCount sayisini bir arttirma
                await unitOfWork.GetRepository<Articlee>().UpdateAsync(article); // ViewCount sayisini bir arttirdigimiz icin Article tablosunu guncelleme islemi
                await unitOfWork.SaveAsync(); // degisiklikleri kaydetme islemi
            }

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
