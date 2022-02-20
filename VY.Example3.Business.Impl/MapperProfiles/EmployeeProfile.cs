using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Entities;
using VY.Example3.Dtos;

namespace VY.Example3.Business.Impl.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}
