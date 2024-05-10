using System.ComponentModel.DataAnnotations;

namespace gestionresto1.Models
{
    public class User
    {
        [Key]
        public int idusers { get; set; }

        public string nom { get; set; }
        public string prenom { get; set; }
        public string cin { get; set; }
        public string password { get; set; }

    }
}
