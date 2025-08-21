using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Token;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Infrastructure.Token
{
    public class TokenService: ITokenService
    {
        private readonly TokenSettings _tokenSettings;
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(IOptions<TokenSettings> options, IUnitOfWork unitOfWork)
        {
            _tokenSettings = options.Value;
            _unitOfWork = unitOfWork;
        }


        public async Task<JwtSecurityToken> CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            var token = new JwtSecurityToken(

                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMunites),
                claims: claims,
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)


            );

            return token;
        }














    }
}
