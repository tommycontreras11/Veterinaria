using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace Capa_Presentacion.Controllers
{
    public class Cita_UsuarioController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Cita_Usuarios
        public ActionResult Index()
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
            var cita_Usuario = _Negocio.Proc_listarCita_Usuario();
            return View(cita_Usuario);
        }

        public ActionResult listarCitaUsuario()
        {
            var cita_Usuario = _Negocio.Proc_listarCita_Usuario();
            return Json(cita_Usuario, JsonRequestBehavior.AllowGet);
        }

        // GET: Cita_Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cita_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cita_Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita_Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cita_Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Cita_Usuario cita_Usuario)
        {
            try
            {
                // TODO: Add update logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita_Usuario/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        //POST: Cita_Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
