using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VY.Example3.Business.Contracts.Services;

namespace VY.Example3.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opResult = await _employeeService.GetAllEmployees();
            
            if (opResult.HasSomeException()) { return StatusCode(500); }

            if (opResult.HasErrors()) { return BadRequest(); }

            if (!opResult.Result.Any()) { return NoContent(); }

            return Ok(opResult.Result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var opResult = await _employeeService.GetEmployeeById(id);

            if (opResult.HasSomeException()) { return StatusCode(500); }

            if (opResult.HasErrors()) { return BadRequest(); }

            if (opResult.Result == null) { return NoContent(); }

            return Ok(opResult.Result);
        }

        [HttpGet("save/{id}")]
        public async Task<IActionResult> GetAndSaveFile([FromRoute]int id)
        {
            var opResult = await _employeeService.GetEmployeeByIdAndAddToFile(id);

            if (opResult.HasSomeException()) { return StatusCode(500); }

            if (opResult.HasErrors()) { return BadRequest(); }

            if (opResult.Result == null) { return NoContent(); }

            return Ok(opResult.Result);
        }




    }
}
