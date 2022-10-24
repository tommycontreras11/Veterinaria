using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class HomeController : Controller
    {
        AccountController account = new AccountController();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 1)
                {
                    ViewBag.idRol = "Administrador";
                    Session["Rol"] = 1;
                }
                else if (account.IsValid(User.Identity.Name) == 2)
                {
                    ViewBag.idRol = "Usuario";
                    Session["Rol"] = 2;
                }
            }
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}