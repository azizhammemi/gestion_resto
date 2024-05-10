using gestionresto1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestionresto1.Controllers
{
    public class commandeController : Controller
    {
        // GET: commandeController

        private readonly RestoContext context;

        public commandeController(RestoContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string userSurname = HttpContext.Session.GetString("UserSurname");
            string cin = HttpContext.Session.GetString("cin");
            string password = HttpContext.Session.GetString("password");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userSurname))
            {
                if (userName != "aziz" && userSurname != "aziz")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.UserName = userName;
                    ViewBag.UserSurname = userSurname;
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
            List<Commande> commandes = context.Commandes.ToList();

            return View(commandes);
        }

        // GET: commandeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: commandeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: commandeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commande commande)
        {

            try
            {
               

                context.Commandes.Add(commande);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: commandeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: commandeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: commandeController/Delete/5
        public ActionResult Delete(int id)
        {
            Commande commande = context.Commandes.Find(id);
            return View(commande);
        }

        // POST: commandeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Commande commande)
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
