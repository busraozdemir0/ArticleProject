using Article.Data.UnifOfWorks;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
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

        public DashboardService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
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
    }
}
