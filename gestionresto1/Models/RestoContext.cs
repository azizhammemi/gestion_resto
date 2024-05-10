using Microsoft.EntityFrameworkCore;

namespace gestionresto1.Models
{
    public class RestoContext : DbContext
    {
        public RestoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }

        public DbSet<User> Users { get; set; }

        
    }
}
