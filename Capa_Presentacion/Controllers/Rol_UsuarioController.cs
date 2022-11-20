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
    public class Rol_UsuarioController : Controller
    {

        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Rol_Usuario
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
            return View();
        }

        // GET: Rol_Usuario/Rol_Usuarios
        //public ActionResult Rol_Usuarios()
        //{
        //    if (User.Identity.IsAuthenticated) 
        //    {
        //        if (account.IsValid(User.Identity.Name) == 2) 
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else 
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    return View();
        //}

        public ActionResult listarRol_Usuario()
        {
            var rol_Usuario = _Negocio.Proc_listarRol_Usuario();
            return Json(rol_Usuario, JsonRequestBehavior.AllowGet);
        }

        //// GET: Rol_Usuario/Create
        //public ActionResult Create()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (account.IsValid(User.Identity.Name) == 2)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    return View();
        //}

        //// POST: Rol_Usuario/Create
        //[HttpPost]
        //public ActionResult Create(int id_Rol, int id_Usuario)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        _Negocio.Proc_actualizarServicio(servicio);
        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Rol_Usuario/Edit/5
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
            var rol_Usuario = _Negocio.Proc_listarRol_UsuarioPorid_Usuario(id);
            return View(rol_Usuario);
        }

        // POST: Rol_Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id_Rol, int id_Usuario)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarRol_Usuario(id_Rol, id_Usuario);
                this.AddNotification("Se ha actualizado el rol de usuario exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Index", "Rol_Usuario");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol_Usuario/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Rol_Usuario/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    // TODO: Add delete logic here
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (account.IsValid(User.Identity.Name) == 2)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    _Negocio.Proc_eliminarRol_Usuario(id);
        //    this.AddNotification("Se ha eliminado el rol de usuario exitosamente", NotificationType.SUCCESS);
        //    return RedirectToAction("Rol_Usuarios", "Rol_Usuario");
        //}
    }
}
