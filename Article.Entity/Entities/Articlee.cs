using Article.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class Articlee:EntityBase
    {
        public Articlee() // ici dolu constructor yaptiysak default Constructor mutlaka olmak zorunda
        {

        }
        public Articlee(string title, string content, Guid userId, Guid categoryId, Guid imageId)  // kod okunabilirligi acisindan Entity Constructure kullaniriz (zorunlu olmayan alanlari barindirmadik)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
       


    }
}
