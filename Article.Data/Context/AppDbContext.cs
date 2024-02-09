using Article.Data.Mappings;
using Article.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Article.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>  // Identity'de gecerli olmasini istedigimiz nesneleri buraya gectik
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Articlee> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model olusturulmadan once yapabilecegimiz configurasyonlar burada yapılır

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }
}
