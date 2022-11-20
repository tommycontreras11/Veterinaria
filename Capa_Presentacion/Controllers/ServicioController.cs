using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using System.Web.Services.Description;
using Capa_Presentacion.Extensions;

namespace Capa_Presentacion.Controllers
{
    public class ServicioController : Controller
    {

        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Servicio/Servicios
        public ActionResult Servicios()
        {
            return View();
        }

        public ActionResult listarServicio()
        {
            var servicio = _Negocio.Proc_listarServicio();
            return Json(servicio, JsonRequestBehavior.AllowGet);
        }

        // GET: Servicio/Create
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

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(Servicio servicio)
        {
            try
            {
                // TODO: Add insert logic here
                
                _Negocio.Proc_crearServicio(servicio);
                this.AddNotification("Se ha creado el servicio exitosamente", NotificationType.SUCCESS);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Edit/5
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
            var servicio = _Negocio.Proc_listarServicioPorid_Servicio(id);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(Servicio servicio)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarServicio(servicio);
                this.AddNotification("Se ha actualizado el servicio exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Servicios", "Servicio");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Servicio/Delete/5
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
            _Negocio.Proc_eliminarServicio(id);
            this.AddNotification("Se ha eliminado el servicio exitosamente", NotificationType.SUCCESS);
            return RedirectToAction("Servicios", "Servicio");
        }
    }
}
