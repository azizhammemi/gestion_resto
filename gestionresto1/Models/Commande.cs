using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionresto1.Models
{
    public class Commande
    {
        [Key]
        public int idcommande { get; set; }
        public string nomuser { get; set; }
        public string prenomuser { get; set; }

        public string nomproduit { get; set; }
        public string numero { get; set; }
        public int quantity { get; set; }

        public int prix { get; set; }
        public string image { get; set; }
       

    }
}
