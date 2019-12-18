using DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChineseApi.Helper
{
    public class TokenGenerator
    {
        private readonly AppSettings _appSettings;
        public TokenGenerator(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public void TokenGenerate(CheckLoginDto checkLogin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            string vip = "VIP";
            if (!checkLogin.IsVip || !checkLogin.VipExp.HasValue||checkLogin.VipExp.Value<DateTime.Now)
                vip = "";

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, checkLogin.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, vip));
            //IDictionary<string, object> tokenClaims = new Dictionary<string, object>();
            //tokenClaims.Add("IsVip", checkLogin.IsVip);
            foreach (string role in checkLogin.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( claims.ToArray() ),
                Expires = DateTime.UtcNow.AddDays(7),
                //Claims = tokenClaims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            checkLogin.Token = tokenHandler.WriteToken(token);
        }
    }
}
