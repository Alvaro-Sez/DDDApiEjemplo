using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Example3.Data.Contracts.Repositories
{
    public interface IFileRepository
    {
        void AddToFile<T>(T entity);
    }
}
