using Article.Data.Context;
using Article.Data.Repositories.Abstractions;
using Article.Data.Repositories.Concretes;
using Article.Data.UnifOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // her IRepository cagrildiginda Repository classi kullanmasi gerektigini belirtiyor
            
            services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))); // baglanti stringinin servis olarak belirtilmesi

            services.AddScoped<IUnitOfWork, UnitOfWork>();  // DI cercevesi kullanimi icin yapilmaktadir. IUnitOfWork istendiginde UnitOfWork kullanilsin demektir.

            return services;
        }
    }
}
