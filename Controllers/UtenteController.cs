using Microsoft.AspNetCore.Mvc;
using WebAPIVenditaSolo.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIVenditaSolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        // GET: api/<UtenteController>
        [HttpGet]
        public async Task<ActionResult<List<Utente>>> Get()
        {
            return new List<Utente>();
        }

        // GET api/<UtenteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UtenteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UtenteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UtenteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
