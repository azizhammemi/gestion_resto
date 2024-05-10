using gestionresto1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestionresto1.Controllers
{
    public class userController : Controller
    {
        // GET: userController
        private readonly RestoContext context;

        public userController(RestoContext context)
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
            List<User> users = context.Users.ToList();

            return View(users);
        }

        // GET: userController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: userController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (context.Users.Where(x => x.cin == user.cin || x.prenom==user.prenom).Count() > 0)
                    {
                        ViewBag.Messageerreur = "le users existe";
                        return View(user);

                    }

                    context.Users.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
              
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: userController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: userController/Edit/5
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

        // GET: userController/Delete/5
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
            User users = context.Users.Find(id);
            return View(users);
        }

        // POST: userController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,  User user)
        {
            try
            {
                context.Users.Remove(user);
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
