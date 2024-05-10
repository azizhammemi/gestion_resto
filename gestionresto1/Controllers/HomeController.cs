using gestionresto1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
namespace gestionresto1.Controllers
{
    public class HomeController : Controller
    {


        private readonly RestoContext context;
        public HomeController(RestoContext context)
        {
            this.context = context;

        }

        public ActionResult Index()
        {
            List<Produit> produit = context.Produits.Include(x => x.Categorie).ToList();
            ViewBag.categorielist = context.Categories.ToList();


            // Pass the name and surname to the view
            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");
            string cin = HttpContext.Session.GetString("cin");
            string password = HttpContext.Session.GetString("password");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                ViewBag.UserName = userName;
                ViewBag.UserSurname = userSurname;
                ViewBag.cin = cin;
                ViewBag.password = password;
                return View(produit);
            }
            return View(produit);
            //    return RedirectToAction("login", "Login");

        }

        public IActionResult Privacy(int? categoryId)
        {
            List<Produit> produits ;
            List<Categorie> categories = context.Categories.ToList();

            if (categoryId != null)
            {
                produits = context.Produits
                    .Include(x => x.Categorie)
                    .Where(p => p.categrieId == categoryId)
                    .ToList();
            }
            else
            {
                produits = context.Produits.Include(x => x.Categorie).ToList();
            }

            var catpr = new catprod
            {
                Categories = categories,
                Produits = produits
            };

            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                ViewBag.UserName = userName;
                ViewBag.UserSurname = userSurname;

                return View(catpr);
            }

            return View(catpr);
            // return RedirectToAction("login", "Login");
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Logout()
        {
            // Ajoutez ici le code nécessaire pour effectuer la déconnexion,
            // par exemple : supprimer les informations d'identification de la session ou du cookie d'authentification
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");  // Redirige vers la page de connexion après la déconnexion
        }
        public IActionResult ajoutercommande(int id)
        {
            Produit produit = context.Produits.Find(id);
            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");
            string cin = HttpContext.Session.GetString("cin");
            string password = HttpContext.Session.GetString("password");

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                ProduitCommandeViewModel viewModel = new ProduitCommandeViewModel
                {
                    Produit = produit,
                    Commande = new Commande(),
                    UserName = userName,
                    UserSurname = userSurname,
                    Cin = cin,
                    Password = password
                };
                ViewBag.UserName = userName;
                ViewBag.userSurname = userSurname;

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "login");
            }

        }
        // HomeController.cs

        [HttpPost]
        public IActionResult Ajouter(string nomproduit, string numero, int quantity, int prix, string image)
        {

            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");
            string cin = HttpContext.Session.GetString("cin");
            string password = HttpContext.Session.GetString("password");
            // Valider et traiter les données de la commande

             if (!string.IsNullOrEmpty(nomproduit)  && !string.IsNullOrEmpty(numero) && quantity > 0)
            {
                // Effectuer les opérations nécessaires, par exemple, persister les données dans la base de données ou exécuter d'autres logiques métier
                Commande commande = new Commande();
                commande.prenomuser = userName;
                commande.nomuser = userSurname;
                commande.numero = numero ;
                commande.quantity = quantity ;
                commande.prix = prix ;
                commande.image = image ;
                commande.nomproduit= nomproduit ;
                context.Commandes.Add(commande);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));

           }
            
            return View();
        }

        public ActionResult listcommande()
        {
            List<Commande> commandes = context.Commandes.ToList();

            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                ViewBag.UserName = userName;
                ViewBag.UserSurname = userSurname;

                return View(commandes);
            }

            return View();
        }
        public ActionResult Deletecommande(int id)
        {
            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                ViewBag.UserName = userName;
                ViewBag.UserSurname = userSurname;

            
            }
            Commande commande = context.Commandes.Find(id);
            return View(commande);
        }

        // POST: userController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletecmd(int id, Commande commande)
        {
            try
            {
                context.Commandes.Remove(commande);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
