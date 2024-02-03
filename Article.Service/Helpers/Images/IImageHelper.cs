using Article.Entity.DTOs.Images;
using Article.Entity.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name,IFormFile imageFile,ImageType imageTypes,string folderName=null);
        void Delete(string imageName);
    }
}
