using System.ComponentModel.DataAnnotations;

namespace WebAPIVenditaSolo.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; } //proprietà chiamata id diviene automaticamente PrimaryKey altrimenti usare annotation [Key]
                                    // [Column("Categoria")] //senza annotazione sarebbe impossibile chiamare la proprietà come la classe
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public IEnumerable<Prodotto> Prodotti { get; set; }



    }
}
