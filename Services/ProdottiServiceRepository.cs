using WebAPIVenditaSolo.DataSource;
using WebAPIVenditaSolo.Entities;
using WebAPIVenditaSolo.Repository;

namespace WebAPIVenditaSolo.Services
{
    public class ProdottiServiceRepository : IProdottiServiceRepository
    {

        IProdottiRepository _repProdotti;

     //   private ILogger<string> _logger;


       

        public ProdottiServiceRepository(IProdottiRepository repProdotti, ILogger<string> logger)
        {
                _repProdotti = repProdotti;
     //           _logger = logger;
        }
        public async Task<int> AddProdotto(Prodotto p)
        {
            try
            {
                return await _repProdotti.CreaProdotto(p);
            }
            catch (Exception ex)
            {
      //          _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<int> DeleteProdotto(int id)
        {
            try
            {
                return await _repProdotti.CancellaProdotto(id);
            }
            catch (Exception ex)
            {
      //         _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<List<Prodotto>> GetProdotti()
        {
            
            {
                try
                {
                    return await _repProdotti.RestituisciProdotti(); 
                }
                catch (Exception ex)
                {
       //             _logger.LogError(ex.Message);
                    throw;
                }

            }
        }

        public async Task<List<Prodotto>> GetProdottiDaCategoria(int idCategoria)
        {

            try
            {
                return await _repProdotti.ProdottiDaCategoria(idCategoria);

            }
            catch (Exception ex)
            {
    //            _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Prodotto> GetProdotto(int id)
        {
            

            try
            {
                return await _repProdotti.RestituisciProdotto(id);

            }
            catch (Exception ex)
            {
      //          _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateProdotto(int id, Prodotto p)
        {
            try
            {
                return await _repProdotti.AggiornaProdotto(id, p);

            }
            catch (Exception ex)
            {
       //         _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
