using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //Bu servis aracı ile sistem Register yada login olma işlemi yapılır.
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password); // Sisteme kaydolma işlemi
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto); // Sisteme giriş işlemi

        Task<IResult> UserExists(string email); // //Bir kullanıcı kayıt olmaya çalıştığında böyle bir email var mı yokmu onu kontrol ediyor.

        IDataResult<AccessToken> CreateAccessToken(User user); // Token üretmek için
    }
}
