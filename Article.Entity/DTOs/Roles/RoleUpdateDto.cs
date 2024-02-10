using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.DTOs.Roles
{
    public class RoleUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public Guid ConcurrencyStamp { get; set; }


    }
}
