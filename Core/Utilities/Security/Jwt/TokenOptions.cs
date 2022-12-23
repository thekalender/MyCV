using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    //3
    //Token üretmen için verilmesi gereken özellikler
    //Token bilgilerini appsettings içinde tutulur
    public class TokenOptions
    {
        public string Audience { get; set; } //Tokenın kullanıcı kitlesi
        public string Issuer { get; set; } // Tokenı imzalayan
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
