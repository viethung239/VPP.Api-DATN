using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Mapping;
using VPP.Application.Services;
using VPP.Application.Services.Role;
using VPP.Application.Services.User;
using VPP.Application.Services.UserRole;
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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
          
            return services;
        }
    }
}
