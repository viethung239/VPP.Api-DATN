using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Domain.Entities;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Context;

namespace VPP.Infrastructure.Repositories
{

    public class RoleRepo : Repo<Role>, IRoleRepo
    {
        public RoleRepo(VPPDBContext dBContext, ILogger<Repo<Role>> logger) : base(dBContext, logger) { }
    }

}
