using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Business.Contracts.Domain;
using VY.Example3.Business.Contracts.Services;
using VY.Example3.Data.Contracts.Entities;
using VY.Example3.Data.Contracts.Repositories;
using VY.Example3.Dtos;

namespace VY.Example3.Business.Impl.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMemoryCache _memoryCache;
        public EmployeeService(
            IMapper mapper,
            ILogger<EmployeeService> logger,
            IEmployeeRepository employeeRepository,
            IFileRepository fileRepository,
            IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeRepository = employeeRepository;
            _fileRepository = fileRepository;
            _memoryCache = memoryCache;
        }

        public Task<OperationResult<EmployeeDto>> AddEmployee(EmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        public OperationResult<EmployeeDto> AddEmployeeTofile(EmployeeDto dto)
        {
            OperationResult<EmployeeDto> result = new OperationResult<EmployeeDto>();
            try
            {
                var target = _mapper.Map<EmployeeDto, Employee>(dto);
                _fileRepository.AddToFile(target);
            }
            catch (Exception ex)
            {
                result.AddErrors(ex);
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            OperationResult<IEnumerable<EmployeeDto>> result = new OperationResult<IEnumerable<EmployeeDto>>();
            try
            {
                List<EmployeeDto> employeesDtos;
                if(_memoryCache.TryGetValue("Employees",out employeesDtos))
                {
                    result.SetResult(employeesDtos);
                    _logger.LogInformation("from cache");
                }
                else
                {
                    var employees = await _employeeRepository.GetAllAsync();
                    if (employees.Any())
                    {
                        var target = _mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(employees);
                        _memoryCache.Set("Employees", target);
                        result.SetResult(target);
                        return result;
                    }
                    result.AddErrors(new ErrorObject { Message = "there are no Employees" });
                }
            }
            catch (Exception ex)
            {
                result.AddErrors(ex);
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<OperationResult<EmployeeDto>> GetEmployeeById(int id)
        {
            OperationResult<EmployeeDto> result = new OperationResult<EmployeeDto>();
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if(employee != null)
                {
                    var target = _mapper.Map<Employee, EmployeeDto>(employee);
                    result.SetResult(target);
                    return result;
                }
                result.AddErrors(new ErrorObject { Message = "employee not found" });
            }
            catch (Exception ex)
            {
                result.AddErrors(ex);
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<OperationResult<EmployeeDto>> GetEmployeeByIdAndAddToFile(int id)
        {
            OperationResult<EmployeeDto> result = new OperationResult<EmployeeDto>();
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if(employee != null)
                {
                    var target = _mapper.Map<Employee,EmployeeDto>(employee);
                    AddEmployeeTofile(target);
                    result.SetResult(target);
                    return result;
                }
                result.AddErrors(new ErrorObject { Message = "employee not found" });
            }
            catch (Exception ex)
            {
                result.AddErrors(ex);
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public Task<OperationResult> RemoveEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
