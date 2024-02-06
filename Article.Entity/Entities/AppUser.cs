using Article.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class AppUser:IdentityUser<Guid>,IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("b261570a-0301-4ddd-a575-418a31f466ba");
        public Image Image { get; set; }
        public ICollection<Articlee> Articles { get; set; }  // bir User birden fazla makale yazabilir
    }
}
