using Article.Entity.DTOs.Categories;
using Article.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.DTOs.Articles
{
    public class ArticleUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }  // resmin guncellenmesi zorunlu olmadigi icin IFormFile? seklinde null olabilir anlaminda yaptik
        public IList<CategoryDto> Categories { get; set; }
    }
}
