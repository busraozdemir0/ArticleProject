using Article.Data.UnifOfWorks;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Concrete
{
    public class DashboardService:IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public DashboardService(IUnitOfWork unitOfWork,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) 
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<List<int>> GetYearlyArticleCounts() // yillik yayinlanan makale analizi
        {
            var articles = await unitOfWork.GetRepository<Articlee>().GetAllAsync(x => !x.IsDeleted); // silimemis olan makaleleri aliyoruz

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year,1,1); // mevcutta olunan yilin 1. ayinin 1. gunu  (startDate.Year => mevcutta olunan yil)

            List<int> datas = new(); // veya = new List<int>();

            for (int i = 1; i <= 12; i++) // 12 ayin her bir ayinda kac makale paylasilmissa eklenerek donecek
            {
                var startedDate=new DateTime(startDate.Year,i,1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x=>x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }
            return datas;
        }
        public async Task<int> GetTotalArticleCount() // toplam makale sayisi(hem silinmis hem silinmemis makaler baz alinacak)
        {
            var articleCount = await unitOfWork.GetRepository<Articlee>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount() // toplam kategori sayisi
        {
            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }

        public async Task<int> GetTotalAdminCount()
        {
            List<AppUser> adminCount = await userManager.Users.ToListAsync(); // tum kullanicilar listeleniyor

            int count = 0;

            foreach(var user in adminCount)  // kullanicilar uzerinde gezinerek
            {
                if(string.Join("", await userManager.GetRolesAsync(user)) == "Admin" || string.Join("", await userManager.GetRolesAsync(user)) == "SuperAdmin") // kullanicinin rolü Admin veya SuperAdmin ise count 1 arttirilacak
                {
                    count++;
                }
            }

            return count;
        }

        public async Task<int> GetTotalRoleCount()
        {
            var roleCount=await roleManager.Roles.CountAsync();
            return roleCount;
        }

        public async Task<int> GetTotalArticleViewsCount()
        {
            List<Articlee> articles = await unitOfWork.GetRepository<Articlee>().GetAllAsync();

            int totalViews = 0;

            foreach(var article in articles)
            {
                totalViews = totalViews + article.ViewCount;
            }
            return totalViews;
        }
    }
}
