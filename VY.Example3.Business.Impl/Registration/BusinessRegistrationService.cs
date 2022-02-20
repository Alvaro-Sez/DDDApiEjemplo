using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Business.Contracts.Services;
using VY.Example3.Business.Impl.Services;
using VY.Example3.Data.Impl.Registration;

namespace VY.Example3.Business.Impl.Registration
{
    public  static class BusinessRegistrationService
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IEmployeeService, EmployeeService>();
            service.AddDataServices(configuration);
            return service;
        }
    }
}
