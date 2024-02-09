using Article.Entity.DTOs.Articles;
using Article.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Abstractions
{
    public interface IArticleService
    {
        // Asenkron(islemlerin ayni anda calismamasi) bir islem yaptigimiz icin Task eklemeyi unutmamaliyiz
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();  // tum makaleleleri kategorleriyle birlikte silinmemis olanlari getir  
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();  // silinmis olan makaleleri kategorileriyle birlikte listelemek icin
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);  // guncellenen makalenin basligini cekebilmek icin string tipinde donus gerceklestirdik
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId); // silinmis makaleyi geri almak icin
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<List<ArticleDto>> GetAllArticlesMostViewedAsync(); // ana sayfada en cok goruntulenen 3 makale listelenecek
    }
}
