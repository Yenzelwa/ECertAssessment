using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECertAssessment.API.Common;
using ECertAssessment.API.Models;
using ECertAssessment.Application.AppUser.Dto;
using Microsoft.IdentityModel.Tokens;

namespace ECertAssessment.API.Providers.Security
{
    public class JwtProvider
    {
        private IAppSettings _settings;
        public JwtProvider(IAppSettings settings)
        {
            _settings = settings;
        }

        public UserLoginModel GetTokenResponse(string username, AppUserDto user)
        {
            var claims = new List<Claim>
            {      CreateClaim(JwtRegisteredClaimNames.Sub, username),
                   CreateClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   CreateClaim("FirstName", user.Email),
                   CreateClaim("LastName", user.PasswordHash),
                   CreateClaim(JwtRegisteredClaimNames.Email, user?.Email ?? "" )
            };

            var now = DateTime.Now;
            var expiresOnUtc = now.AddMinutes(_settings.JWT.TokenExpiresMins);
            var token = GenerateToken(username, claims, expiresOnUtc);
            var userResponse = new UserLoginModel
            {
                Email = username,
                Token = new Token
                {
                    access_token = token,
                    type = _settings.JWT.TokenType,
                    expires = expiresOnUtc,
                    issued = DateTime.Now
                }
            };

            return userResponse;
        }

        private  string GenerateToken(string username, List<Claim> claims, DateTime expiresOnUtc)
        {
            var symmetricKey = Encoding.UTF8.GetBytes(_settings.JWT.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiresOnUtc,

                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public  ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Encoding.UTF8.GetBytes(_settings.JWT.SecretKey);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception ex)
            {
                var msg = ex;
                return null;
            }
        }

        private static Claim CreateClaim(string type, string value)
        {
            var claim = new Claim(type, value);
            return claim;
        }

        public  List<Claim> GetClaims(string token)
        {
            var simplePrinciple = GetPrincipal(token);
            var id = simplePrinciple.Identity as ClaimsIdentity;
            var claims = id?.Claims.ToList();
            return claims;
        }

        public  Token RefreshToken(string token)
        {
            try
            {
                var claims = GetClaims(token);
                var simplePrinciple = GetPrincipal(token).Identity as ClaimsIdentity;
                var username = GetClaimValue<string>(JwtRegisteredClaimNames.Sub, simplePrinciple);
                var now = DateTime.Now;
                var expiresOnUtc = now.AddMinutes(_settings.JWT.TokenExpiresMins).ToUniversalTime();
                var newToken = GenerateToken(username, claims, expiresOnUtc);

                var tokenDetails = new Token
                {
                        access_token = newToken,
                        type = _settings.JWT.TokenType,
                        expires = expiresOnUtc
                };

                return tokenDetails;
            }

            catch (Exception ex)

            { 

                throw ex;
            }

        }

        public static T GetClaimValue<T>(string type, ClaimsIdentity id)
        {
            var claims = id?.Claims.ToList();
            var value = claims?.SingleOrDefault(clm => clm.Type == type)?.Value;

            var tType = typeof(T);

            if (tType == typeof(string))
                return (T)(object)value;

            if (tType == typeof(int))
                return (T)(object)Convert.ToInt32(value);

            if (tType == typeof(long))
                return (T)(object)Convert.ToInt64(value);

            if (tType == typeof(DateTime))
                return (T)(object)Convert.ToDateTime(value);

            if (tType == typeof(bool))
                return (T)(object)Convert.ToBoolean(value);

            if (tType == typeof(decimal))
                return (T)(object)Convert.ToDecimal(value);

            //return string by default
            return (T)(object)value;
        }


    }
}

