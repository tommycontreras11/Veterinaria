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
    public class CitaController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Cita
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET: Cita/Procesar
        public ActionResult Procesar(int id)
        {
            ViewBag.id_Cita = id;
            return View();
        }

        [HttpPost]
        public ActionResult Procesar()
        {
            ViewBag.id_Cita = "Cita " + Request.Form["id"];
            _Negocio.Proc_actualizarCitaPorid_Cita(int.Parse(Request.Form["id"]));
            this.AddNotification("La cita ha finalizado exitosamente", NotificationType.SUCCESS);
            return View();
        }

        // GET: Cita/Citas
        public ActionResult Citas()
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

        public ActionResult listarCita()
        {
            var cita = _Negocio.Proc_listarCita();
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCitaPorid_Usuario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarCitaPorid_Usuario(id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCitaPorid_Usuario_id_UsuarioVeterinario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarCitaPorid_Usuario_id_UsuarioVeterinario(id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarservicioPorid_Usuario() 
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarservicioPorid_Usuario(id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarservicioPorid_Usuario_id_UsuarioVeterinario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarservicioPorid_Usuario_id_UsuarioVeterinario(id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCitaPorfecha_Cita()
        {
            var cita = _Negocio.Proc_listarCitaPorfecha_Cita(DateTime.Now.ToString("yyyy/MM/dd"));
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarTodaCitaPorfecha_Cita()
        {
            var cita = _Negocio.Proc_listarTodaCitaPorfecha_Cita(DateTime.Now.ToString("yyyy/MM/dd"));
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCitaPorfecha_Cita_id_Usuario()
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarCitaPorfecha_Cita_id_Usuario(DateTime.Now.ToString("yyyy/MM/dd"), id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (account.IsValid(User.Identity.Name) == 1) 
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

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            try
            {
                // TODO: Add insert logic here
                if (Request.Form["mascota"].ToString() == "Aún no tienes una mascota") 
                {
                    this.AddNotification("Debes de tener una mascota antes de realizar una cita", NotificationType.WARNING);
                }
                else 
                {

                    var cantidadCitas = _Negocio.Proc_comprobarCantidadCita(DateTime.Now.ToString("yyyy/MM/dd"));

                    if (cantidadCitas <= 5) 
                    {

                        Cita_Usuario cita_Usuario = new Cita_Usuario();
                        //DateTime date = new DateTime(long.Parse(Request.Form["fecha_Cita"]));
                        //cita.fecha_Cita = String.Format("{0: dd/MM/yyyy HH:mm tt}", date);
                        cita.servicio = Request.Form["servicio"];
                        //cita.fecha_Creacion = cita.fecha_Cita;
                        //cita.fecha_Modificacion = cita.fecha_Cita;
                        cita_Usuario.id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
                        cita_Usuario.id_Mascota = _Negocio.Proc_listarid_MascotaPornombre_Completo(Request.Form["mascota"]);
                        cita_Usuario.id_UsuarioVeterinario = int.Parse(Request.Form["doctor"]);
                        
                        cita.comprobar_Cita = false;
                        _Negocio.Proc_crearCita(cita);
                        
                        cita_Usuario.id_Cita = _Negocio.Proc_listarid_CitaPorMascota(cita.mascota);
 

                        _Negocio.Proc_crearCita_Usuario(cita_Usuario);

                        this.AddNotification("Se ha creado la cita exitosamente", NotificationType.SUCCESS);
                    }
                    else 
                    {
                        this.AddNotification("Lo sentimos, por hoy no se aceptan más citas", NotificationType.WARNING);
                    }

                }
                
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Edit/5
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
            var cita = _Negocio.Proc_listarCitaPorid_Cita(id);
            return View(cita);
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(Cita cita)
        {
            try
            {
                // TODO: Add update logic here
                _Negocio.Proc_actualizarCita(cita);
                this.AddNotification("Se ha actualizado la cita exitosamente", NotificationType.SUCCESS);
                return RedirectToAction("Citas", "Cita");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Cita/Delete/5
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
            this.AddNotification("Se ha eliminado la cita exitosamente", NotificationType.SUCCESS);
            _Negocio.Proc_eliminarCita(id);
            return RedirectToAction("Citas", "Cita");
        }
    }
}
