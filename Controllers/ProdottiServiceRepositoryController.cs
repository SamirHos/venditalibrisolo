using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIVenditaSolo.DTO;
using WebAPIVenditaSolo.Entities;
using WebAPIVenditaSolo.Services;

namespace WebAPIVenditaSolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiServiceRepositoryController : ControllerBase
    {
        IProdottiService _service;
        public ProdottiServiceRepositoryController(IProdottiService service)

            => _service = service;




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
        //[HttpGet("{id}")]
        //public async Task<ActionResult<InfoProdottoDTO>> Get(int id)
        //{
        //    var prodottoDTO = await _service

        //}
           
        //{
        //    var prodotto = await _service.RestituisciProdotto(id);
        //    return prodotto;
        //}

        //// POST api/<ProdottiServiceController>
        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] CreaProdottoDTO pDTO)
        //{
        //    int numeroRecord = 0;
        //    try
        //    {   
        //        Prodotto p = new Prodotto();
        //        p.Nome = pDTO.NomeProdotto;
        //        p.Prezzo = pDTO.Prezzo;
        //       // p.CategoriaNome = _repCategorie.getNomeCategoria(pDTO.CategoriaId); questo è il modo per utilizzare le repositoryu
        //        numeroRecord = await _service.CreaProdotto(pDTO);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        //return Problem(ex.Message)
        //        if (numeroRecord != 1)
        //        {
        //            return Problem("operazione non effettuata");
        //        }
        //        else
        //        {
        //            return Problem("non riuscito");
        //        }
        //    }
        //}

        //// PUT api/<ProdottiServiceController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] Prodotto p)
        //{
        //    var prodottoDaModificare = _service.AggiornaProdotto(id, p);
        //    return Ok("il prodotto è stato modificato");
        //}

        //// DELETE api/<ProdottiServiceController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var prodottoDaCancellare = await _service.CancellaProdotto(id);
        //    if (prodottoDaCancellare >0)

            
        //    return Ok();

        //    else return BadRequest();

        //}






    }




}











