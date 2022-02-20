using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Entities;

namespace VY.Example3.Data.Contracts.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee,int>
    {
    }
}
