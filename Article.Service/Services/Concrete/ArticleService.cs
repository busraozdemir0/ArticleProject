using Article.Data.UnifOfWorks;
using Article.Entity.Entities;
using Article.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Articlee>> GetAllArticleAsync()
        {
            return await unitOfWork.GetRepository<Articlee>().GetAllAsync();
        }
    }
}
