using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;

namespace Capa_Presentacion.Controllers
{
    public class CitaController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();

        AccountController account = new AccountController();

        // GET: Cita
        public ActionResult Index()
        {
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

        public ActionResult listarservicioPorid_Usuario() 
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var cita = _Negocio.Proc_listarservicioPorid_Usuario(id_Usuario);
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarCitaPorfecha_Cita()
        {
            var cita = _Negocio.Proc_listarCitaPorfecha_Cita(DateTime.Now.ToString("dd/MM/yyyy"));
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarTodaCitaPorfecha_Cita()
        {
            var cita = _Negocio.Proc_listarTodaCitaPorfecha_Cita(DateTime.Now.ToString("dd/MM/yyyy"));
            return Json(cita, JsonRequestBehavior.AllowGet);
        }

        // GET: Cita/Create
        public ActionResult Create()
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

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            try
            {
                // TODO: Add insert logic here
                cita.id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
                cita.id_Mascota = _Negocio.Proc_listarid_MascotaPornombre_Completo(Request.Form["mascota"]);
                cita.id_UsuarioVeterinario = int.Parse(Request.Form["doctor"]);

                //DateTime date = new DateTime(long.Parse(Request.Form["fecha_Cita"]));
                //cita.fecha_Cita = String.Format("{0: dd/MM/yyyy HH:mm tt}", date);
                cita.servicio = Request.Form["servicio"];
                //cita.fecha_Creacion = cita.fecha_Cita;
                //cita.fecha_Modificacion = cita.fecha_Cita;

                _Negocio.Proc_crearCita(cita);
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
                _Negocio.Proc_eliminarCita(id);
                return RedirectToAction("Citas", "Cita");
            }
            catch
            {
                return View();
            }
        }
    }
}
