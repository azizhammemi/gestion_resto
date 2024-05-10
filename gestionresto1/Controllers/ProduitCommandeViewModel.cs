using gestionresto1.Models;

namespace gestionresto1.Controllers
{
    public class ProduitCommandeViewModel
    {
        public Produit Produit { get; set; }
        public Commande Commande { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Cin { get; set; }
        public string Password { get; set; }
    }
}
