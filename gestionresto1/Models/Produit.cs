using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionresto1.Models
{
    public class Produit
    {
        [Key]
        public int idProduit { get; set; }
        public string name { get; set; }
         public string description { get; set; }
        public int prix { get; set; }
        public string image { get; set; }
        [ForeignKey("categrieId")]
        public int? categrieId { get; set; }
        public virtual Categorie? Categorie { get; set; }


    }
}
