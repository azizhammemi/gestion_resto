using gestionresto1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestionresto1.Controllers
{
    public class ProduitController : Controller
    {
        // GET: ProduitController

        private readonly RestoContext context;

        public ProduitController(RestoContext context)
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
            ViewBag.categorielist = context.Categories.ToList();

            List<Produit> produit = context.Produits.Include(x=>x.Categorie).ToList();

            return View(produit);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProduitController/Create
        public ActionResult Create()
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
            ViewBag.categorielist = context.Categories.ToList();
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit produit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (context.Produits.Where(x => x.name == produit.name).Count() > 0)
                    {
                        ViewBag.errorMessage = "L' Produits existe";
                        return View(produit);
                    }

                    context.Produits.Add(produit);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.categorielist = context.Categories.ToList();
                return View(produit);
            }
            
            catch
            {
                return View();
            }
          
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
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
            ViewBag.categorielist = context.Categories.ToList();
            Produit produit = context.Produits.Find(id);
            return View(produit);
        }

        // POST: CategorieController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produit produit)
        {
            try
            {
                Produit prod= context.Produits.Find(id);
                prod.name = produit.name;
                prod.description = produit.description;
                prod.prix= produit.prix;
                prod.image = produit.image;
                prod.categrieId = produit.categrieId;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
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
            Produit produit = context.Produits.Find(id);
            return View(produit);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit produit)
        {
            try
            {
                context.Produits.Remove(produit);
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
