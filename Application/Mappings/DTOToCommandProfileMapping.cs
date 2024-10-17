using Application.DTOs;
using Application.Products.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DTOToCommandProfileMapping : Profile
    {
        public DTOToCommandProfileMapping() { 
        
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
        
        }
    }
}
