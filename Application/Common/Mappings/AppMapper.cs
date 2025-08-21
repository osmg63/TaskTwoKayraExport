using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Command.Register;
using Application.Features.Products.Command.CreateProduct;
using Application.Features.Products.Queries.GetAllProduct;
using Application.Features.Products.Queries.GetProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class AppMapper : Profile
    {
        public AppMapper() { 
        
            CreateMap<User,RegisterCommandRequest>().ReverseMap();
            CreateMap<CreateProductCommandRequest, Product>().ReverseMap();
            CreateMap<GetProductQueryResponse, Product>().ReverseMap();
            CreateMap<GetAllProductQueryResponse, Product>().ReverseMap();




        }




    }
}
