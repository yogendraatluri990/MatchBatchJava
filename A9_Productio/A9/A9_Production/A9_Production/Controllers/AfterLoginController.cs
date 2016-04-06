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

     
    




    }
}