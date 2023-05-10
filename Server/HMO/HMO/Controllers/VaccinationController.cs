using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationBL vaccinationServices;
        public VaccinationController(IVaccinationBL vaccinationServices)
        {
            this.vaccinationServices = vaccinationServices;
        }
        // GET: api/<VaccinationController>
        [HttpGet]
        public IEnumerable<Vaccination> Get()
        {
            return this.vaccinationServices.GetVaccinations();
        }

        // POST api/<VaccinationController>
        [HttpPost]
        public bool Post([FromBody] Vaccination value)
        {

            return vaccinationServices.Create(value);

        }

        // PUT api/<VaccinationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VaccinationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
