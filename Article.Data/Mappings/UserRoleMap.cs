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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("324BDFDE-4DDB-4333-9ED1-1E9E91226A73"),
                RoleId= Guid.Parse("5A445B3E-3728-4853-9362-B4FD9AAB42CB")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("2EF7516C-3A35-4B40-A744-C3C7DA3F6E20"),
                RoleId = Guid.Parse("47ACF50F-DB96-4276-AFE3-B86227094670")
            }
            );
        }
    }
}
