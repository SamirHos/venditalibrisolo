using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIVenditaSolo.DataSource;
using WebAPIVenditaSolo.DTO;
using WebAPIVenditaSolo.Entities;

namespace WebAPIVenditaSolo.Services
{
    public class ProdottiService : IProdottiService
    {
       
        private LibreriaContext _libreria;

       //private ILogger<string> _logger;
        

        public ProdottiService(LibreriaContext libreria/*, ILogger<string> logger*/)

        => (_libreria  /*, _logger*/) = (libreria/*, logger*/);


        public async Task<List<Prodotto>> RestituisciProdotti()
        {
  //          _logger.LogError("OOOOOOO");
            try
            {
                var lista = await _libreria.Prodotti.ToListAsync();
                return lista;
            }
            catch (Exception ex) 
            {
  //              _logger.LogError(ex.Message);
                throw ;
            }
           
        }

        public async Task<Prodotto> RestituisciProdotto(int id)
        {
            if (id < 1) throw new Exception("id non valido");

            try
            {

                var prodotto = await _libreria.Prodotti.FindAsync(id);
                return prodotto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
               
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
            catch(Exception ex)
            {
     //           _logger.LogError(ex.Message);
               
                throw;
            }
        }

        public async Task<int> CancellaProdotto(Prodotto p)
        {

            _libreria.Entry(p).State = EntityState.Deleted;
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

        public async Task<int> CreaProdotto(Prodotto p)
        {
            _libreria.Entry(p).State = EntityState.Added;
            try
            {
                
                int numeroRecordsInseriti = await _libreria.SaveChangesAsync();
                if (numeroRecordsInseriti != 1)
                {
                    string MessaggioErrore = "Operazione di inserimento non effettutata";
                    // _logger.LogError(MessaggioErrore)
                    throw new Exception( MessaggioErrore);
                }
                return numeroRecordsInseriti;
            }
            catch 
            {
                throw;
            }
           
        }

        public Task<List<Prodotto>> ProdottiDaCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public Task<int> CancellaProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreaProdotto(CreaProdottoDTO p)
        {
            throw new NotImplementedException();
        }

        object IProdottiService.CancellaProdotto(Prodotto p)
        {
            throw new NotImplementedException();
        }
    }
}
