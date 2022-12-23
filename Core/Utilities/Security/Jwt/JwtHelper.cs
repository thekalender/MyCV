using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    //4
    //Core.Utilities.Security.Encyption uzantısında "CreateSecurityKey" classsını unutma. Sırası 4.1 dir
    //Core.Utilities.Security.Encyption uzantısında "SigningCredentialsHelper" classını unutma. Sırası 4.2 dir
    //Core.Utilities.Hashing uzantısının altında "HashingHelper" classını unutma. Sırası 5 dir
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //IConfiguration kullanabilmek için Microsoft.Extensions.Configuration lazımdır
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // Get kullanabilmen için "microsoft.extensions.configuration.binder" indirmek lazımdır. Ayrıca "TokenOptions" tanımı appsettings.json da tanımlamak gerekmektedir.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); // Core.Utilities.Security.Encyption uzantısında class yazıldı.
            var signingCredentals = SigningCredentialsHelper.CreateSigningCredentials(securityKey); // Core.Utilities.Security.Encyption uzantısında class yazıldı.

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentals, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiriton = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration, // dakika döndüğünden dolayı ctor da dakika formatına uygun kod yazıldı
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims), // Burası aşağıdaki SetClaims metodu getirilir.
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
