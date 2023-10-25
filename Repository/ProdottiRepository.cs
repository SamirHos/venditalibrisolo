using Microsoft.EntityFrameworkCore;
using WebAPIVenditaSolo.DataSource;
using WebAPIVenditaSolo.DTO;
using WebAPIVenditaSolo.Entities;
using WebAPIVenditaSolo.Services;

namespace WebAPIVenditaSolo.Repository
{
    public class ProdottiRepository : IProdottiRepository
    {
        // senza logger

            private LibreriaContext _libreria;

            private ILogger<string> _logger;
            private object prodottoDaVisualizzare;

            public ProdottiRepository(LibreriaContext libreria, ILogger<string> logger)

            => (_libreria, _logger) = (libreria, logger);


            public async Task<List<Prodotto>> RestituisciProdotti()
            {
          //      _logger.LogError("OOOOOOO");
                try
                {
                    var lista = await _libreria.Prodotti.ToListAsync();
                    return lista;
                }
                catch (Exception ex)
                {
            //        _logger.LogError(ex.Message);
                    throw;
                }

            }

            public async Task<Prodotto> RestituisciProdotto(int id)
            {

                var prodotto = await _libreria.Prodotti.FindAsync(id);
                return prodotto;

            }

            public async Task<int> AggiornaProdotto(int id, Prodotto p)
            {


            try
            {

                p.IdProdotto = id;
                int numeroRecords = 0;


                _libreria.Entry(p).State = EntityState.Modified;
                numeroRecords = await _libreria.SaveChangesAsync();

                if (numeroRecords > 0)
                {
                    return numeroRecords;
                }
                else throw new Exception("aggiornamento non effettuato");


            }
            catch (Exception ex)
            {
       //         _logger.LogError(ex.Message);
                throw;
            }



        }

            public async Task<int> CancellaProdotto(int id)
            {
            _libreria.Entry(id).State = EntityState.Deleted;
            try
            {

                int cancellati = await _libreria.SaveChangesAsync();
                if (cancellati != 1)
                {
                    string MessaggioErrore = "Operazione di cancell non effettutata";
                    // _logger.LogError(MessaggioErrore)
                    throw new Exception(MessaggioErrore);
                }
                return cancellati;
            }
            catch
            {
                throw;
            }

        }

            public async Task<int> CreaProdotto(CreaProdottoDTO p)
            {

            Prodotto prodottoEntity = new Prodotto
            {
                Nome = p.Name,
                Prezzo = p.Price
            };




                _libreria.Entry(p).State = EntityState.Added;
                try
                {

                    int numeroRecordsInseriti = await _libreria.SaveChangesAsync();
                    if (numeroRecordsInseriti != 1)
                    {
                        string MessaggioErrore = "Operazione di inserimento non effettutata";
                        // _logger.LogError(MessaggioErrore)
                        throw new Exception(MessaggioErrore);
                    }
                    return numeroRecordsInseriti;
                }
                catch
                {
                    throw;
                }

            }

            public  Task<List<Prodotto>> ProdottiDaCategoria(int idCategoria)
            {
                throw new NotImplementedException();
            }

        public Task<int> CreaProdotto(Prodotto p)
        {
            throw new NotImplementedException();
        }
    }
    }
