using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A9_Production.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register u)
        {

            if (ModelState.IsValid)
            {

                using (DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3())
                {
                    u.Role_Id = 1;
                    u.CanLogin = true;
                    u.IsAdmin = false;
                    db.Registers.Add(u);
                    db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "Registration is Successful";

                    if (ViewBag.Message != null)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }


            }
            return View(u);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                using (DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3())
                {
                    var Logged = db.Users.Where(a => a.UserName.Equals(u.UserName) && a.Password.Equals(u.Password) && a.ISACTIVE.Equals(true)).FirstOrDefault();

                    if (Logged != null)
                    {
                        Session["LoggedId"] = Logged.Id.ToString();
                        Session["LoggedUserName"] = Logged.UserName.ToString();
                        return RedirectToAction("After_Login", "AfterLogin");
                    }
                }
            }
            return View(u);
        }

        public ActionResult Logoff()
        {
            if (Session["LoggedId"] != null)
            {
                Session.Clear();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public JsonResult Gender()
        {
            using (DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3())
            {

                var Gend = db.Genders.Select(x => new
                {

                    GenderCode = x.GenderCode,
                    GenderName = x.GenderName

                }).ToList();

                return Json(Gend, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Used()
        {
            using (DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3())
            {
                var reg = db.Registers.Select(x => new
                {

                    firstname = x.FirstName,
                    Lastname = x.LastName,
                    Id = x.Id
                }).ToList();
                return Json(reg, JsonRequestBehavior.AllowGet);

            }

        }
        //public JsonResult Country(){
        //    using (DB_A9_SoftwareEntities2 db = new DB_A9_SoftwareEntities2()){
        //        var reg = db.Country.select(x = new );
        //    }
        //}

    }
}
        
