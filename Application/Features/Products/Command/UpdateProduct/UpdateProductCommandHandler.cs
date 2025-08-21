using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MediatR.Pipeline;

namespace Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var data= _unitOfWork.ProductRepository.Get(x => x.Id == request.Id);
            if (data != null)
            {
                _mapper.Map(request, data);
                await _unitOfWork.SaveChangeAsync();
                return Unit.Value;
            }
            throw new Exception("Product Not Found");

        }
    }
}
