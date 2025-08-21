using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Token;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }





        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user= await _unitOfWork.UserRepository.Get(x=>x.Email==request.Email);
            if(user!=null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                JwtSecurityToken token = await _tokenService.CreateToken(user);
                string _token = new JwtSecurityTokenHandler().WriteToken(token);

                return new()
                {
                    Token = _token
                };
            }

            throw new Exception("Kullanıcı bilgileri hatalı");

        }
    }
}
