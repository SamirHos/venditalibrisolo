using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIVenditaSolo.Entities;

namespace WebAPIVenditaSolo.DataSource
{
    public class LibreriaContext : DbContext
    {


        public LibreriaContext()
        {
        }
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
        : base(options)
        {
        }

     public DbSet<Prodotto> Prodotti { get; set; }
     public DbSet <Categoria> Categorie { get; set; }  
    }
}
