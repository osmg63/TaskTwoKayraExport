using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
    {
        public int Id { get; set; }     
    }
}
