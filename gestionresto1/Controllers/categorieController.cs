using gestionresto1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestionresto1.Controllers
{
    public class categorieController : Controller
    {

        private readonly RestoContext context;

        public categorieController(RestoContext context)
        {
            this.context = context;
        }
        // GET: categorieController
        public ActionResult Index()
        {
            List<Categorie> Categories = context.Categories.ToList();

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


            return View(Categories);
        }
          
        

        // GET: CategorieController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategorieController1/Create
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

            return View();
        }

        // POST: CategorieController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categorie)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (context.Categories.Where(x => x.Nom == categorie.Nom).Count() > 0)
                    {
                        ViewBag.Messageerreur = "le service existe";
                        return View(categorie);

                    }
                    Categorie categorie1 = new Categorie();
                    categorie1.Nom = categorie.Nom;
                    context.Categories.Add(categorie1);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: CategorieController1/Edit/5
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
            ViewBag.categorieList = context.Categories.ToList();
            Categorie categorie = context.Categories.Find(id);
            return View(categorie);
        }

        // POST: CategorieController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categorie categorie)
        {
            try
            {
                Categorie ca = context.Categories.Find(id);
                ca.Nom = categorie.Nom;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController1/Delete/5
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
            Categorie categorie = context.Categories.Find(id);
            return View(categorie);
        }

        // POST: CategorieController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categorie categorie)
        {
            try
            {
                context.Categories.Remove(categorie);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void redrect()
        {

        }
    }
}
