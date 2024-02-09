using Article.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class ArticleVisitor :IEntityBase
    {
        public ArticleVisitor()
        {
            
        }
        public ArticleVisitor(Guid articleId, int visitorId)
        {
            ArticleId=articleId;
            VisitorId=visitorId;
        }
        // iki adet pk degeri tasiyacak olan tablo ( Hem visitors tablosuyla hem de Articles tablosuyla iliski kurarak coka cok iliskiyi olusturacak)
        public Guid ArticleId { get; set; }
        public Articlee Article { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
    }
}
