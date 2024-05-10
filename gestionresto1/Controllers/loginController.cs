using gestionresto1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestionresto1.Controllers
{
    public class loginController : Controller
    {
        // GET: loginController
        private readonly RestoContext context;

        public loginController(RestoContext context)
        {
            this.context = context;
        }



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string cin, string password)
        {
            // Validate the user's credentials from the database
            User user = context.Users.FirstOrDefault(u => u.cin == cin && u.password == password);

            if (user != null)
            {

                HttpContext.Session.SetString("UserName", user.nom);
                HttpContext.Session.SetString("UserSurname", user.prenom);
                HttpContext.Session.SetString("password", user.password);
                HttpContext.Session.SetString("cin", user.cin);
                if (user.cin=="aziz" && user.password =="aziz")
                {
                    return RedirectToAction("Index", "categorie", new { name = user.nom, surname = user.prenom });

                }
                else
                {
                    // Store user information in session or authentication cookie, if desired
                    return RedirectToAction("Index", "Home", new { name = user.nom, surname = user.prenom });
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials";
                return View();
            }
        }
        public ActionResult Logout()
        {
            // Ajoutez ici le code nécessaire pour effectuer la déconnexion,
            // par exemple : supprimer les informations d'identification de la session ou du cookie d'authentification
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "login");  // Redirige vers la page de connexion après la déconnexion
        }

    }
}
