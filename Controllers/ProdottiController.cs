using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WebAPIVenditaSolo.DataSource;
using WebAPIVenditaSolo.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIVenditaSolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private LibreriaContext _libreria;
        public ProdottiController(LibreriaContext libreria)
            => _libreria = libreria;



        // GET: api/<ProdottiController>
        [HttpGet]
        public async Task<ActionResult<List<Prodotto>>> GetElencoProdotti()
        {
            try
            {
                var lista = _libreria.Prodotti.ToList();
                return (lista.Count > 0) ? lista : NotFound("lista vuota");
                // if lista.count>0 return lista 
                // else return notfound("lista vuota")
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // GET api/<ProdottiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodotto>> GetProdotto(int id)
        {
            Prodotto? prodotto = await _libreria.Prodotti.FindAsync(id);
            return prodotto != null ? prodotto : NotFound("prodotto insesistente");
        }

        // POST api/<ProdottiController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Prodotto p)
        {
            _libreria.Entry(p).State = EntityState.Added;
            // _libreria.Prodotti.Add(p);

            try
            {
                await _libreria.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ProdottiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Prodotto p)
        {
            var  prodottoDaModificare = await GetProdotto(id);
            if (prodottoDaModificare != null)
            {
                try
                {

                    _libreria.Entry(p).State = EntityState.Modified;
                    await _libreria.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else 
                return NotFound();
        }

        // DELETE api/<ProdottiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prodottoDaCancellare = await GetProdotto(id);
            if (prodottoDaCancellare != null)
            {
                try
                {
                    _libreria.Entry(prodottoDaCancellare).State = EntityState.Deleted;
                    await _libreria.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else return NotFound();
        }


        [HttpGet("prodottoDaCategoria/{categoriaId}")]
        public async Task<ActionResult<List<Prodotto>>> GetProdottoDaCategoria(int categoriaId)
        {
            var prodotti = (from p in _libreria.Prodotti
                          where p.IdProdotto== categoriaId
                          select p);
            return (prodotti.Count() >0 ) ? prodotti.ToList() : NotFound("lista vuota");


        }






    }

}
