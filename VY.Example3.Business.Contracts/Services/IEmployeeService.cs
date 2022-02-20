using System.Collections.Generic;
using System.Threading.Tasks;
using VY.Example3.Business.Contracts.Domain;
using VY.Example3.Dtos;

namespace VY.Example3.Business.Contracts.Services
{
    public interface IEmployeeService
    {
        OperationResult<EmployeeDto> AddEmployeeTofile(EmployeeDto dto);
        Task<OperationResult> RemoveEmployee(int id);
        Task<OperationResult<EmployeeDto>> AddEmployee(EmployeeDto dto);

        Task<OperationResult<IEnumerable<EmployeeDto>>> GetAllEmployees();
        Task<OperationResult<EmployeeDto>> GetEmployeeById(int id);
        Task<OperationResult<EmployeeDto>> GetEmployeeByIdAndAddToFile(int id);
    }
}