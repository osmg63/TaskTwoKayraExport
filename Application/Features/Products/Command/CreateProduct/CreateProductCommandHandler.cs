using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Command.CreateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data= _mapper.Map<Product>(request);
            await _unitOfWork.ProductRepository.AddAsync(data);
            await _unitOfWork.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
