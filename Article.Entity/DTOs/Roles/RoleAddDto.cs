using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.DTOs.Roles
{
    public class RoleAddDto
    {
        public string Name { get; set; }
        public Guid ConcurrencyStamp { get; set; }
    }
}
