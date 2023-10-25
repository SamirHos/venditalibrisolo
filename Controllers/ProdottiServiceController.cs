using Microsoft.AspNetCore.Mvc;
using WebAPIVenditaSolo.Entities;
using WebAPIVenditaSolo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIVenditaSolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiServiceController : ControllerBase
    {
        IProdottiService _service;
        public ProdottiServiceController(IProdottiService service)

            => _service = service;
        
        // GET: api/<ProdottiServiceController>
        [HttpGet]
        public async Task<ActionResult<List<Prodotto>>> GetElencoProdotti()
        {



            try
            {
                var lista = await _service.RestituisciProdotti();
                return lista;
            }
            catch (Exception ex)
            {
                return Problem("al momento non è possibile soddisfare la richiesta");
            }
        }

        // GET api/<ProdottiServiceController>/5
        [HttpGet("{id}")]
        public async Task<Prodotto> Get(int id)
        {
            var prodotto = await _service.RestituisciProdotto(id);
            return prodotto;
        }

        // POST api/<ProdottiServiceController>
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] Prodotto p)
        {
            int numeroRecord=0;
            try
            {
                numeroRecord= await _service.CreaProdotto(p);
                return Ok();
            }
            catch (Exception ex) 
            {
                //return Problem(ex.Message)
                if (numeroRecord != 1)
                {
                    return Problem("operazione non effettuata");
                }
                else
                {
                    return Problem("non riuscito");
                }
            }
        }

        // PUT api/<ProdottiServiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Prodotto p)
        {
            var prodottoDaModificare = _service.AggiornaProdotto(id, p);
            return Ok("il prodotto è stato modificato");
        }

        // DELETE api/<ProdottiServiceController>/5
        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(Prodotto p)
        {

            var prodottoDaEliminare = _service.CancellaProdotto(p);
            return null;

        }
    }
}
