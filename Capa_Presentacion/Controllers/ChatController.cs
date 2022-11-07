using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Capa_Presentacion.Controllers
{
    public class ChatController : Controller
    {
        Clase_Negocio _Negocio = new Clase_Negocio();
        AccountController account = new AccountController();
        public int idRespuesta;

        // GET: Chat
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

        [HttpPost]
        public ActionResult Index(int id, string comentario)
        {
            Chat chat = new Chat();
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            chat.id_Usuario = id_Usuario;
            chat.id_UsuarioRespuesta = id;
            chat.comentario = comentario;
            _Negocio.Proc_crearChat(chat);

            return View();
        }

        public ActionResult Chat() {

            //if (account.IsValid(User.Identity.Name) == 1)
            //{
            //    var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            //    var nombre = _Negocio.Proc_listarnombre_CompletoPorid_Usuario(id_Usuario);

            //    Session["nombre"] = nombre + " (Veterinaria)";
            //}
            //else if (account.IsValid(User.Identity.Name) == 2)
            //{
                //var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
                //var nombre = _Negocio.Proc_listarnombre_CompletoPorid_Usuario(id_Usuario);
                //Session["nombre"] = nombre;
            
            return View();
        }

        public ActionResult listarChat() 
        {
            var chat = _Negocio.Proc_listarChat();
            return Json(chat, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarChatPorid_ChatUsuario(int id)
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var chat = _Negocio.Proc_listarChatPorid_Usuario(id, id_Usuario);
            return Json(chat, JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarcomentarioPorid_Usuario(int id)
        {
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            var chat = _Negocio.Proc_listarcomentarioPorid_Usuario(id_Usuario, id);
            return Json(chat, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult comentario(int id) {
        //    idRespuesta = id;
        //    ViewBag.id = idRespuesta;
        //    return Json(id, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult listarcomentarioPorid_Usuario()
        //{
        //    var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
        //    var chat = _Negocio.Proc_listarcomentarioPorid_Usuario(id_Usuario, idRespuesta);
        //    return Json(chat, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult listarChatPorid_UsuarioRespuesta()
        //{
        //    var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
        //    var chat = _Negocio.Proc_listarChatPorid_Usuario(idRespuesta, id_Usuario);
        //    return Json(chat, JsonRequestBehavior.AllowGet);
        //}

        //            using (var cmd = new SqlCommand(@"SELECT [id_Usuario], [nombre_Completo] FROM Usuario as usuario INNER JOIN Rol_Usuario as rol on rol.id_Usuario = usuario.id_Usuario WHERE id_Rol = 1", con))
        SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["CustomVeterinariaEntities"].ConnectionString);
        public List<Usuario> GetAllAdmin()
        {
            var messages = new List<Usuario>();
            using (var cmd = new SqlCommand(@"SELECT usuario.id_Usuario, usuario.nombre_Completo FROM Usuario as usuario INNER JOIN Rol_Usuario as rol on rol.id_Usuario = usuario.id_Usuario WHERE id_Rol = 1", con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDependency.Start(ConfigurationManager.ConnectionStrings["CustomVeterinariaEntities"].ConnectionString);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                if (con.State == ConnectionState.Closed) 
                    con.Open();

                using (var reader = cmd.ExecuteReader()) {
                    return reader.Cast<IDataRecord>().
                        Select(x => new Usuario()
                        {
                            id_Usuario = x.GetInt32(0),
                            nombre_Completo = x.GetString(1)
                        }).ToList();
                }
            }
        }

        public List<Usuario> GetAllUser()
        {
            var messages = new List<Usuario>();
            using (var cmd = new SqlCommand(@"SELECT usuario.id_Usuario, usuario.nombre_Completo FROM Usuario as usuario INNER JOIN Rol_Usuario as rol on rol.id_Usuario = usuario.id_Usuario WHERE id_Rol = 2", con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDependency.Start(ConfigurationManager.ConnectionStrings["CustomVeterinariaEntities"].ConnectionString);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Cast<IDataRecord>().
                        Select(x => new Usuario()
                        {
                            id_Usuario = x.GetInt32(0),
                            nombre_Completo = x.GetString(1)
                        }).ToList();
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e) //this will be called when any changes occur in db table.    
        {
             MyHub.Show();    
        }

        public ActionResult GetMessages()
        {
            List<Usuario> messages = new List<Usuario>();
            messages = GetAllAdmin();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMessages4()
        {
            List<Usuario> messages = new List<Usuario>();
            messages = GetAllUser();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public List<Chat> GetAllMessage(int id)
        {
            var messages = new List<Usuario>();
            var id_Usuario = _Negocio.Proc_listarid_UsuarioPorEmail(User.Identity.Name);
            using (var cmd = new SqlCommand(@"SELECT chat.id_Chat, chat.id_Usuario, chat.id_UsuarioRespuesta, chat.comentario, chat.fecha_Creacion FROM Chat as chat WHERE (chat.id_Usuario = '" + id + "' AND chat.id_UsuarioRespuesta = '" + id_Usuario + "') OR (chat.id_UsuarioRespuesta = '" + id + "' AND chat.id_Usuario = '" + id_Usuario + "')", con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDependency.Start(ConfigurationManager.ConnectionStrings["CustomVeterinariaEntities"].ConnectionString);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Cast<IDataRecord>().
                        Select(x => new Chat()
                        {
                            id_Chat = x.GetInt32(0),
                            id_Usuario = x.GetInt32(1),
                            id_UsuarioRespuesta = x.GetInt32(2),
                            comentario = x.GetString(3),
                            fecha_Creacion = x.GetString(4)
                        }).ToList();
                }
            }
        }

        public ActionResult GetMessages2(int id)
        {
            List<Chat> messages = new List<Chat>();
            messages = GetAllMessage(id);
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
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

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
