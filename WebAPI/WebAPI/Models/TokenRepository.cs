using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models.Tables;
using System.Security.Principal;

namespace WebAPI.Models
{
    public class TokenRepository
    {
        private MyContext context = new MyContext();
        private UserRepository rep = new UserRepository();
        private string key = "NasTajnySecretChat";
        public string GetToken(Login login)
        {       
            User foo = rep.FindByUserName(login.userName);
            
            if (foo != null)
            {
                bool ifPasswordIsCorrect = foo.Password == login.password;
                if(ifPasswordIsCorrect)
                {
                    Token toDbToken = new Token();

                    var issuer = "http://localhost:4200/";
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var permClaims = new List<Claim>();
                    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    permClaims.Add(new Claim("name", login.userName));


                    var token = new JwtSecurityToken(issuer,
                                    issuer,
                                    permClaims,
                                    expires: DateTime.UtcNow.AddSeconds(15),
                                    signingCredentials: credentials); 

                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

                    //toDbToken.TheToken = jwt_token;
                    //toDbToken.ID_User = user.ID;
                    //toDbToken.Expire_time = token.Payload.Exp.ToString();
                    //this.context.Tokens.Add(toDbToken);
                    //this.context.SaveChanges();

                    return jwt_token;
                }
                return null;
                
            }
            else
                return null;
        }
        public bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
            
        }
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is expiration in the generated token
                ValidateAudience = false, // Because there is audiance in the generated token
                ValidateIssuer = false,   // Because there is issuer in the generated token
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.FromSeconds(1),
                ValidIssuer = "http://localhost:4200/",
                ValidAudience = "http://localhost:4200/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.key)) // The same key as the one that generate the token
            };
        }
    }
}