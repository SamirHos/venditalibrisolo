using WebAPIVenditaSolo.Entities;

namespace WebAPIVenditaSolo.Services
{
    public interface IProdottiServiceRepository
    {
        //CRUD base
        Task<List<Prodotto>> GetProdotti();
        Task<Prodotto> GetProdotto(int id);
        Task<int> AddProdotto(Prodotto p);
        Task<int> UpdateProdotto(int id,Prodotto p);
        Task<int> DeleteProdotto(int id);

        // metodi di BL
        Task<List<Prodotto>> GetProdottiDaCategoria(int idCategoria);
    }
}
