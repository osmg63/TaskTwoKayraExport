using Domain.Entities;
using System.IdentityModel.Tokens.Jwt;


namespace Application.Interfaces.Token
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user);

    }
}
