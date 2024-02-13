using Article.Data.Context;
using Article.Data.UnifOfWorks;
using Article.Entity.DTOs.Users;
using Article.Entity.Entities;
using Article.Entity.Enums;
using Article.Service.Extensions;
using Article.Service.Helpers.Images;
using Article.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork,IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.imageHelper = imageHelper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);

            map.UserName = userAddDto.Email; // proje senaryomuzda email ile kullanici adi ayni olacagi icin bastan esitliyoruz.
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password); // Null hatasindan dolayi; Sifre eger bossa "" bunu gonderecek. Bos degilse o password'u gonderecek
            if (result.Succeeded) // kullanici olusturma islemi basariliysa o kullaniciya rol ekleme islemleri yapilacak ve result dondurulecek
            {
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)  // Controller'da Item1, Item2 cikmasi yerine identityResul, email cikacak
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await userManager.DeleteAsync(user); // Identity'nin ondelete metodlarında eger bir kullanici silinirse kullaniciya bagli olan roller de silinir.+
                                                              // Bu yüzden ayriyetten rol silme silemi yapmamiza gerek kalmaz.
            if (result.Succeeded)
                return (result, user.Email);
            else
                return (result, null);

        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync(); // tum rolleri bul
            return roles;
        }

        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map) // maplenmis user'lar uzerinde gez
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());  // user'in id'sini bul
                var role = string.Join("", await userManager.GetRolesAsync(findUser));  // kullanicinin rolünü bul
                                                                                        //bu separator roller arasina koyacagi karakteri ifade eder
                item.Role = role;
            }

            return map;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user)); // gelen kullanicinin rolunu cek ve don
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user); // bulunan kullanicinin rolunu cekecek olan metot

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole); // oncelikle kullanici uzerinde yer alan rolu kaldiriyoruz
                var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString()); // selectlist'den secilen rolun id'sine gore rolu bul
                await userManager.AddToRoleAsync(user, findRole.Name); // bulunan rolu guncellenecek olan kullaniciya ata

                return result;
            }
            else
                return result;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var getUserWithImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image); // x=>x.Image > image'ini include etmek istedigimiz icin bu sekilde kullaniyoruz

            var map = mapper.Map<UserProfileDto>(getUserWithImage);

            map.Image.FileName = getUserWithImage.Image.FileName;

            return map;
        }
        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            // resim yukleme islemleri
            var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName} {userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            return image.Id;
        }

        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);

            Guid imageId = user.ImageId; // Giris yapan kullanicinin image id'si

            var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword); // mevcuttaki sifre dogruysa true donecek
            if (isVerified && userProfileDto.NewPassword != null) // eger yeni sifre alanina deger girilmisse yani bos degilse sifre degistirme islemi yap
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync(); // sifre degistirildigi icin cikis yaptiriliyor
                    await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false); // cikis yaptirildiktan sonra yeni sifreyle tekrar giris yaptirildi

                    mapper.Map(userProfileDto,user); // mapleme islemi

                    user.ImageId = imageId;

                    if (userProfileDto.Photo != null) // resim sectiyse resim yukleme islemi
                        user.ImageId = await UploadImageForUser(userProfileDto);
                    
                    await userManager.UpdateAsync(user);
                    await unitOfWork.SaveAsync();

                    return true;
                }
                else
                    return false;
                

            }
            else if (isVerified)
            {
                

                await userManager.UpdateSecurityStampAsync(user);

                mapper.Map(userProfileDto,user); // mapleme islemi

                user.ImageId = imageId; // Giris yapan kullanicinin image id bilgisi ataniyor

                if (userProfileDto.Photo != null) // eger kullanici resim sectiyse resim yukleme isleminin ardindan ImageId bilgisi guncelleniyor
                    user.ImageId = await UploadImageForUser(userProfileDto);


                await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();

                return true;

            }

            else
                return false;

        }
    }
}
