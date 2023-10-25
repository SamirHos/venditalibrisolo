using Microsoft.AspNetCore.Mvc;
using WebAPIVenditaSolo.DTO;
using WebAPIVenditaSolo.Entities;

namespace WebAPIVenditaSolo.Services
{
    public interface IProdottiService
    {

        Task<List<Prodotto>> RestituisciProdotti();
        Task<Prodotto> RestituisciProdotto(int id);
        Task<int> CreaProdotto(CreaProdottoDTO p);
        Task<int> AggiornaProdotto(int id,Prodotto p);
        Task<int> CancellaProdotto(int id );

        Task<List<Prodotto>> ProdottiDaCategoria(int idCategoria);
        Task<int> CreaProdotto(Prodotto p);
        object CancellaProdotto(Prodotto p);
    }
}
