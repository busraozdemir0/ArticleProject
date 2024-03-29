﻿using Article.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Article.Entity.DTOs.Users
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; } // null olabilir yapmamizin sebebi => kisi eger parolasini degistermek istemiyorsa 
        public IFormFile? Photo {  get; set; }
        public Image Image { get; set; }
    }
}
