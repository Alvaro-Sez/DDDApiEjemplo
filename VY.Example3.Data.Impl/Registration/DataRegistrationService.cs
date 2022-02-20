using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Repositories;
using VY.Example3.Data.Impl.Context;
using VY.Example3.Data.Impl.Repositories;

namespace VY.Example3.Data.Impl.Registration
{
    public static class DataRegistrationService
    {
        public static IServiceCollection AddDataServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<NorthwindDbContext>(builder =>
            {
                builder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlServer(configuration.GetConnectionString("Northwind"));
            });
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            service.AddTransient<IFileRepository>(c=> new FileRepository(configuration["StringPath"]));
            return service;
        }
    }
}
