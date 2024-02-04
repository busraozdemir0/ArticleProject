using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("25A68467-8A27-45B7-9202-50241CEA50FC");
        public Image Image { get; set; }
        public ICollection<Articlee> Articles { get; set; }  // bir User birden fazla makale yazabilir
    }
}
