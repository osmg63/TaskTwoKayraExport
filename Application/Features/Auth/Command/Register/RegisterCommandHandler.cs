using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using MediatR;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 12);
            var data = await _unitOfWork.UserRepository.AddAsync(_mapper.Map<User>(request));
            await _unitOfWork.SaveChangeAsync();
            return Unit.Value;
        }


    }
}
