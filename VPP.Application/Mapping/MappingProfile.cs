using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Entities;

namespace VPP.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryGroup, CategoryGroupDto>().ReverseMap();
            CreateMap<CompanySupplier, CompanySupplierDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();  
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<WareHouse, WareHouseDto>().ReverseMap();
            CreateMap<WareHouseDetail, WareHouseDetailDto>().ReverseMap();
            
        }
    }
}
