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
        

    }
}
