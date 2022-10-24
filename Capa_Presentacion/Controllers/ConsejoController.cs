using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace Capa_Presentacion.Controllers
{
    public class ConsejoController : Controller
    {

        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();
        
        // GET: Consejo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Consejo/Consejos
        public ActionResult Consejos()
        {
            return View();
        }

        public ActionResult listarConsejo()
        {
            var consejo = _Negocio.Proc_listarConsejo();
            return Json(consejo, JsonRequestBehavior.AllowGet);
        }

        // GET: Consejo/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // POST: Consejo/Create
        [HttpPost]
        public ActionResult Create(Consejo consejo)
        {
            try
            {
                // TODO: Add insert logic here
                consejo.id_Tipo = int.Parse(Request.Form["tipoMascota"]);
                consejo.id_Raza = int.Parse(Request.Form["razaMascota"]);
                _Negocio.Proc_crearConsejo(consejo);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Consejo/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            var consejo = _Negocio.Proc_listarConsejoPorid_Consejo(id);
            return View(consejo);
        }

        // POST: Consejo/Edit/5
        [HttpPost]
        public ActionResult Edit(Consejo consejo)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarConsejo(consejo);
                return RedirectToAction("Consejos", "Consejo");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consejo/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Consejo/Delete/5
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (User.Identity.IsAuthenticated)
                {
                    if (account.IsValid(User.Identity.Name) == 2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
                _Negocio.Proc_eliminarConsejo(id);
                return RedirectToAction("Consejos", "Consejo");
            }
            catch
            {
                return View();
            }
        }
    }
}
