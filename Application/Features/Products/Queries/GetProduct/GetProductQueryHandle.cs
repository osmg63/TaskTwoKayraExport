using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryHandle : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductQueryHandle(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data= await _unitOfWork.ProductRepository.Get(x => x.Id == request.Id);
            if (data == null)
                throw new Exception("Product Not Found");

           return _mapper.Map<GetProductQueryResponse>(data);

        }
    }
}
