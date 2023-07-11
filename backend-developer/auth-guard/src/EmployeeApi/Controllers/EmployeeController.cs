using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Validator;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        IMapper _mapper;
        public EmployeeController(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEmplooye")]
        public IEnumerable<Employee> Get()
        {

            return _dbContext.Employees.ToArray();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound();

        }

        [HttpPost(Name = "AddEmplooye")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest request)
        {

            EmployeeValidator validator = new EmployeeValidator(_dbContext);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errorCollection = validationResult.Errors.Select(x => x.ErrorMessage);
                return BadRequest(errorCollection);
            }

            Employee employee = _mapper.Map<EmployeeRequest, Employee>(request);
            employee.Id = Guid.NewGuid();
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return new ObjectResult(employee) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] EmployeeRequest request)
        {

          
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee!=null) {
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.Email = request.Email;
                employee.Age = request.Age;
                employee.Gender = request.Gender;
                employee.Phone = request.Phone;

               await _dbContext.SaveChangesAsync();
                return Ok(employee);
            }

            return NotFound();
           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();

        }
    }
    

}

