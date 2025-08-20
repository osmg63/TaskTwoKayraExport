using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class AppMapper : Profile
    {
        public AppMapper() { 
        
            CreateMap<User,RegisterCommandRequest>().ReverseMap();
        
        }




    }
}
