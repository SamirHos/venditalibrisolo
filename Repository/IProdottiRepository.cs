using WebAPIVenditaSolo.Entities;

namespace WebAPIVenditaSolo.Repository
{
    public interface IProdottiRepository
    {


        Task<List<Prodotto>> RestituisciProdotti();
        Task<Prodotto> RestituisciProdotto(int id);
        Task<int> CreaProdotto(Prodotto p);
        Task<int> AggiornaProdotto(int id, Prodotto p);
        Task<int> CancellaProdotto(int id);

        Task<List<Prodotto>> ProdottiDaCategoria(int idCategoria);

    }
}
