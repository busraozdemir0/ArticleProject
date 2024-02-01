using Article.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public ICollection<Articlee> Articles { get; set; }
    }
}
