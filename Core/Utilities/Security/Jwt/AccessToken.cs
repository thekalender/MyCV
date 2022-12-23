using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    //1
    //Erişim tokenıdır
    //Bizim kullanıcımızın kayıt veya login olduktan sonra kullanıcımıza verdiğimiz token classıdır.
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiriton { get; set; } // Bu bilgi bizim tokenımızın ne kadar geçerli olduğunu bilgisini verir.
    }
}
