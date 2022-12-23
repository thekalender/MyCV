using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    //2
    //Token üretmek için yazılan metoddur
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);// Kullanıcı bilgisi(user) ile rolü(operationClaims) vermiş oluyoruz.
    }
}
