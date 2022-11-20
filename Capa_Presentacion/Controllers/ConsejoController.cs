using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using Capa_Presentacion.Extensions;

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

        public ActionResult listarConsejoPorid_Tipo_id_Raza(int id_Tipo, int id_Raza) 
        {
            var consejo = _Negocio.Proc_listarConsejoPorid_Tipo_id_Raza(id_Tipo, id_Raza);
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
                this.AddNotification("Se ha creado el consejo exitosamente", NotificationType.SUCCESS);
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
                this.AddNotification("Se ha actualizado el consejo exitosamente", NotificationType.SUCCESS);
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
            this.AddNotification("Se ha eliminado el consejo exitosamente", NotificationType.SUCCESS);
            return RedirectToAction("Consejos", "Consejo");
        }
    }
}
