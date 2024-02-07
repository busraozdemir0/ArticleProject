using Article.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.DTOs.Articles
{
    public class ArticleListDto
    {
        public IList<Articlee> Articles { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual int CurrentPage { get; set; } = 1;  // ilk basta 1. sayfada olsun
        public virtual int PageSize { get; set; } = 3;  // bir sayfada 3 adet makale olacak
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));  // Toplam kac sayfa olsun
                                                                                                   // Ceiling metodu her zaman ondalikli sayiyi soldaki sayiyi bir arttiriyor, yani her zaman yukari yuvarliyor.
        public virtual bool ShowPrevious => CurrentPage > 1; // bulunan sayfa 1'den buyukse onceki butonu ve sayfalari goster
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false;
    }
}
