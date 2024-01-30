using Article.Data.Context;
using Article.Data.Repositories.Abstractions;
using Article.Data.Repositories.Concretes;
using Article.Data.UnifOfWorks;
using Article.Service.Services.Abstractions;
using Article.Service.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
