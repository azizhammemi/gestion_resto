using System.ComponentModel.DataAnnotations;
namespace gestionresto1.Models
{
    public class Categorie
    {
        [Key]
        public int idCategorie { get; set; }
        
        public string Nom { get; set; }
        
    }
}
