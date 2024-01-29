using Article.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Article.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Articlee>
    {
        public void Configure(EntityTypeBuilder<Articlee> builder)
        {
            builder.Property(x=>x.Title).HasMaxLength(200);
            //builder.Property(x=>x.Title).IsRequired(false);

            builder.HasData(new Articlee
            {
                Id = Guid.NewGuid(),
                Title = "Asp.Net Core Deneme Makalesi",
                Content = "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("D21F1E86-4DDF-4DB0-B469-7BC63C1A7798"),
                ImageId = Guid.Parse("25A68467-8A27-45B7-9202-50241CEA50FC"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },

            new Articlee
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi",
                Content = "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 15,
                CategoryId = Guid.Parse("6BA1F557-0CFF-4AB6-8359-0EA298EEAC6E"),
                ImageId = Guid.Parse("509D3D55-646B-413B-8F3E-01C5DA780F76"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );
        }
    }
}
