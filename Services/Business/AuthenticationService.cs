using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeAPI
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Authentication key
        /// </summary>
        private readonly string key;
        public AuthenticationService(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Creates a JWT if the username and password are valid
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>String containing a JWT</returns>
        public string Authenticate(string username, string password)
        {
            try
            {
                // Authentication will accept any username and password combination with a length greater than 0.
                if (username.Length == 0 || password.Length == 0)
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
