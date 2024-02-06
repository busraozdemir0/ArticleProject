using Article.Data.Context;
using Article.Data.Repositories.Abstractions;
using Article.Data.Repositories.Concretes;
using Article.Data.UnifOfWorks;
using Article.Service.FluentValidations;
using Article.Service.Helpers.Images;
using Article.Service.Services.Abstractions;
using Article.Service.Services.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly= Assembly.GetExecutingAssembly();


            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  // mevcutta olan kullaniciyi(login olmus kullaniciyi) bulmamizi saglayacak olan kisim

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr"); // fluent validation'un turkcelestirilmesi
            });

            return services;
        }
    }
}
