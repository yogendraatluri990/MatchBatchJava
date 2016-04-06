using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace A9_Production.Controllers
{
    public class AfterLoginController : Controller
    {
        private object List;
        // GET: AfterLogin
        public ActionResult After_Login()
        {
            if (Session["LoggedId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult UpdateContact()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContact(Contact c)
        {
            if (ModelState.IsValid)
            {
                using (DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3())
                {

                    db.Contacts.Where(x => x.UserId.Equals(@Session["LoggedId"]) && c.UserId.Equals(@Session["LoggedId"]));

                    //db.Contacts.Add(c).Equals(db.Contacts.Where(x => x.UserId.Equals(@Session["LoggedId"]) && c.UserId.Equals(@Session["LoggedId"])));
                    db.SaveChanges();
                    ModelState.Clear();
                    c = null;
                    ViewBag.Message = "Contact is Update successfully";



                }

            }

            return View(c);
        }


        //public ActionResult Gallery()
        //{
        //    List<AfterLoginController > all = new List<AfterLoginController>();
        //    using(DB_A9_SoftwareEntities3 db = new DB_A9_SoftwareEntities3()){


        //    }

        //    return View();
        //}





    }
}