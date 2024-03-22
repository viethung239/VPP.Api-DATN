using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Repositories;

namespace VPP.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepo,CategoryRepo>();
            services.AddScoped<ICategoryGroupRepo, CategoryGroupRepo>();
            services.AddScoped<ICompanySupplierRepo, CompanySupplierRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRoleRepo, UserRoleRepo>();
            services.AddScoped<IWareHouseRepo, WareHouseRepo>();
            services.AddScoped<IWareHouseDetailRepo, WareHouseDetailRepo>();
            return services;
        }
    }
}
