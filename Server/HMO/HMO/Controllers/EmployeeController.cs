using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL employeeServices;
        public EmployeeController(IEmployeeBL employeeServices)
        {
            this.employeeServices = employeeServices;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee > Get()
        {
            return this.employeeServices.GetEmployees();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool Post([FromBody] Employee value)
        {
          
             return employeeServices.Create(value);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
