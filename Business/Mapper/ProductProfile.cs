using AutoMapper;
using Business.DTO;
using Infra.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile() {
            //CreateMap<Product,ProductDto>();
            CreateMap<Product,ProductDto>().ForMember(p => p.SKU, op => op.MapFrom(s => s.SKU));
            CreateMap<Product,ProductDto>().ForMember(p => p.Description, op => op.MapFrom(s => s.Description));
            CreateMap<Product,ProductDto>().ForMember(p => p.Price, op => op.MapFrom(s => s.Price));
            //CreateMap<Product,ProductDto>().ForMember(p => p.Quantity, op => op.Ignore());
            //CreateMap<Product,ProductDto > ().ForMember(p => p.Id, op => op.Ignore());
        } 
    }
}
