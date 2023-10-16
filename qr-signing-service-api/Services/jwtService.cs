using qr_signing_service_api.Models;

using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace qr_signing_service_api.Services
{
    public class jwtService : IjwtService
    {
        async Task<string> IjwtService.GenerateJWT(Token tokenjwt)
        {
        
            
            string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

           // Create Security key  using private key above:
           // not that latest version of JWT using Microsoft namespace instead of System
           var securityKey = new Microsoft
               .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor securityDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(30),
                
            };
            
            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
           {
               { "file_uuid ", tokenjwt.file_uuid},
               { "workspace", tokenjwt.workspace_id.ToString()},
               { "iat",  tokenjwt.DateTime.ToString() },
           };
            
            //
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            
            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);
           // SecurityToken securityToken = handler.CreateToken(securityDescriptor);



            // And finally when  you received token from client
            // you can  either validate it or try to  read
           // var token = handler.ReadJwtToken(tokenString);
            
            return tokenString;

        }
    }
}
