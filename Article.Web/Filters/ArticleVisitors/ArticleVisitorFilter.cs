using Article.Data.UnifOfWorks;
using Article.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Article.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        // Bu yapi ile sitemize giren insanlarin girdigi andan itibaren bilgilerini kaydedebilecegimiz bir olay yaratacagiz

        
        private readonly IUnitOfWork unitOfWork;

        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //public bool Disable { get; set; }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           // if (Disable) return next();

            List<Visitor> visitors = unitOfWork.GetRepository<Visitor>().GetAllAsync().Result; // tum visitor'lari al

            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); // giren kullanicinin ip adresini aliyoruz
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"]; // Giren kullanicinin tarayici turu, surumu ve isletim sistemi gibi bilgileri iceren UserAgent bilgisini alir.

            Visitor visitor = new(getIp, getUserAgent);

            // Bir kullanici vt'ye sadece bir defa kaydedilecek. Bu yuzden eger giren kullanici vt'de kayitli ise tekrar kaydetmemeliyiz.

            if (visitors.Any(x => x.IpAddress == visitor.IpAddress)) // eger giren kullanici vt'da varsa atlayacak
                return next();

            else // eger yoksa Visitor tablosuna eklenecek
            {
                unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                unitOfWork.Save();
            }
            return next();

        }
    }
}
