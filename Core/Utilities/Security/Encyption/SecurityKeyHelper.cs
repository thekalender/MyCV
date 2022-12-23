using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encyption
{
    // 4.1 : JwtHelper clasınından => önce yazılır ve CreateToken metodunda kullanılır
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) // SecurityKey ve SymmetricSecurityKey kullanabilmek için Microsoft.IdentityModel.Tokens indirmek lazımdır.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
