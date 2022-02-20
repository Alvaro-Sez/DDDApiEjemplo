using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Entities;
using VY.Example3.Data.Contracts.Repositories;
using VY.Example3.Data.Impl.Context;

namespace VY.Example3.Data.Impl.Repositories
{
    public class EmployeeRepository : BaseRepository<NorthwindDbContext, Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindDbContext context) : base(context)
        {
        }
    }
}
