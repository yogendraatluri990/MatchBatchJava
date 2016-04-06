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

                using (DB_A9_SoftwareEntities4 db = new DB_A9_SoftwareEntities4())
                {
                    u.CanLogin = true;                   
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
                using (DB_A9_SoftwareEntities4 db = new DB_A9_SoftwareEntities4())
                {
                    var Logged = db.Users.Where(a => a.Email.Equals(u.Email) && a.Password.Equals(u.Password) && a.ISACTIVE.Equals(true)).FirstOrDefault();

                    if (Logged != null)
                    {
                        Session["LoggedId"] = Logged.Id.ToString();
                        Session["LoggedUserName"] = Logged.Email.ToString();
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
            using (DB_A9_SoftwareEntities4 db = new DB_A9_SoftwareEntities4())
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
            using (DB_A9_SoftwareEntities4 db = new DB_A9_SoftwareEntities4())
            {
                var reg = db.Registers.Select(x => new
                {

                    firstname = x.First_Name,
                    Lastname = x.Last_Name,
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
        
