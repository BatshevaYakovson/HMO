using Microsoft.AspNetCore.Mvc;
using Repositories.Repository.Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseBL diseaseServices;
        public DiseaseController(IDiseaseBL diseaseServices)
        {
            this.diseaseServices = diseaseServices;
        }
        // GET: api/<DiseaseController>
        [HttpGet]
        public IEnumerable<Disease> Get()
        {
            return this.diseaseServices.GetDisease();
        }

        // POST api/<DiseaseController>
        [HttpPost]
        public bool Post([FromBody] Disease value)
        {

            return diseaseServices.Create(value);

        }

        // PUT api/<DiseaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiseaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
