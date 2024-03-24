using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Mapping;
using VPP.Application.Services;
using VPP.Application.Services.Category;
using VPP.Application.Services.CategoryGroup;
using VPP.Application.Services.CompanySupplier;
using VPP.Application.Services.Order;
using VPP.Application.Services.OrderDetail;
using VPP.Application.Services.Post;
using VPP.Application.Services.Product;
using VPP.Application.Services.Role;
using VPP.Application.Services.User;
using VPP.Application.Services.UserRole;
using VPP.Application.Services.WareHouse;
using VPP.Application.Services.WareHouseDetail;
using VPP.Infrastructure.Modules;

namespace VPP.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddInfrastructureModule();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryGroupService, CategoryGroupService>();
            services.AddScoped<ICompanySupplierService, CompanySupplierService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IWareHouseDetailService, WareHouseDetailService>();
          
            return services;
        }
    }
}
