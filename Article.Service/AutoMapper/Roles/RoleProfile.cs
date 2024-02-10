using Article.Entity.DTOs.Roles;
using Article.Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.AutoMapper.Roles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleDto>().ReverseMap();
            CreateMap<AppRole, RoleAddDto>().ReverseMap();
            CreateMap<AppRole, RoleUpdateDto>().ReverseMap();
        }
    }
}
