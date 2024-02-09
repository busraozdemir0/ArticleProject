using Article.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Data.Mappings
{
    public class ArticleVisitorMap:IEntityTypeConfiguration<ArticleVisitor>
    {
        public void Configure(EntityTypeBuilder<ArticleVisitor> builder)
        {
            builder.HasKey(x => new { x.ArticleId, x.VisitorId }); // ArticleVisitor tablosunda iki tane pk degeri tasimasi gerektigi alani kendimiz bu satir ile belirttik
                                                                   // aksi takdirde hata aliriz. (Coka cok iliski kurmak istedigimiz icin bu sekil de yapiyoruz)
        }
    }
}
