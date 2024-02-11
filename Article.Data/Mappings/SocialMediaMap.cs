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
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasData(new SocialMedia
            {
                Id = 1,
                GmailUrl = "test",
                GithubUrl = "test",
                InstagramUrl = "test",
                TwitterUrl = "test",
                LinkedinUrl = "test",
            });
        }
    }
}
