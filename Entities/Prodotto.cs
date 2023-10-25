using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIVenditaSolo.Entities
{
    public class Prodotto
    {

        //[Key] se non termina con Id o se non si chiama Id
        // gli attributi si scrivono sempre tra []
        [Key]
        public int IdProdotto { get; set; }
        [MinLength(4)]
        public string? Nome { get; set; }
        [Required]
        public decimal Prezzo { get; set; }
        public int Giacenza { get; set; }

        public int CategoriaId { get; set; }  

 
    }


   
}



