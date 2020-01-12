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
        private string key = "NasTajnySecretChat";
        public string GetToken(string userName)
        {
            Token toDbToken = new Token();

            var issuer = "http://localhost:4200/";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("name", userName));


            var token = new JwtSecurityToken(issuer,
                            issuer,
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            //toDbToken.TheToken = jwt_token;
            //toDbToken.ID_User = user.ID;
            //toDbToken.Expire_time = token.Payload.Exp.ToString();
            //this.context.Tokens.Add(toDbToken);
            //this.context.SaveChanges();

            return jwt_token;
        }
        public bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = true, // Because there is no audiance in the generated token
                ValidateIssuer = true,   // Because there is no issuer in the generated token
                ValidIssuer = "http://localhost:4200/",
                ValidAudience = "http://localhost:4200/",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.key)) // The same key as the one that generate the token
            };
        }
    }
}