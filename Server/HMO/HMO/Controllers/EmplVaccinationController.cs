using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplVaccinationController : ControllerBase
    {
        private readonly IEmplVaccinationBL emplVaccinationServices;
        public EmplVaccinationController(IEmplVaccinationBL emplVaccinationServices)
        {
            this.emplVaccinationServices = emplVaccinationServices;
        }
        // GET: api/<emplVaccinationController>
        [HttpGet]
        public IEnumerable<EmplVaccination> Get()
        {
            return this.emplVaccinationServices.GetEmplVaccinations();
        }

        // POST api/<emplVaccinationController>
        [HttpPost]
        public bool Post([FromBody] EmplVaccination value)
        {

            return emplVaccinationServices.Create(value);

        }

        // PUT api/<emplVaccinationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<emplVaccinationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
