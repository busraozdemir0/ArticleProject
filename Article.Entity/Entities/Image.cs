using Article.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {
            
        }
        public Image(string fileName, string fileType)
        {
            FileName=fileName;
            FileType=fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Articlee> Articles { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
