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

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryGroup, CategoryGroupDto>();
            CreateMap<CompanySupplier, CompanySupplierDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Product, ProductDto>();  
            CreateMap<Post, PostDto>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<WareHouse, WareHouseDto>();
            CreateMap<WareHouseDetail, WareHouseDetailDto>();
            
        }
    }
}
