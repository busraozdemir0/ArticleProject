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
        Task<List<Articlee>> GetAllArticleAsync();  // Asenkron bir islem yaptigimiz icin Task eklemeyi unutmamaliyiz

    }
}
