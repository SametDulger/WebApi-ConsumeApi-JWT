using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Text;

namespace WebApi
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDYazilimSD2023."));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

    }
}
