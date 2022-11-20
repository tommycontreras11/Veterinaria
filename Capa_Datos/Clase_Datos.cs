using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.ExceptionServices;

namespace Capa_Datos
{
    public class Clase_Datos
    {

        /*----------Tabla Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_loguearse----------*/
        public Proc_loguearse_Result Proc_loguearse(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_loguearse(usuario.email, usuario.password).FirstOrDefault();
            }
        }

        /*----------Proc_listarUsuario----------*/
        public List<Proc_listarUsuario_Result> Proc_listarUsuario() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarUsuario().ToList();
            }
        }

        /*----------Proc_listarAdmin----------*/
        public List<Proc_listarAdmin_Result> Proc_listarAdmin()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarAdmin().ToList();
            }
        }

        /*----------Proc_listarUsuarioPorid_Usuario_Result----------*/
        public Proc_listarUsuarioPorid_Usuario_Result Proc_listarUsuarioPorid_Usuario(int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarUsuarioPorid_Usuario(id_Usuario).FirstOrDefault();
            }
        }

        /*----------Proc_listarid_UsuarioPorEmail----------*/
        public int Proc_listarid_UsuarioPorEmail(string email) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_UsuarioPorEmail @email",
                    new SqlParameter("@email", email)).FirstOrDefault();
            }
        }

        public List<string> email = new List<string>();
        /*----------Proc_listarEmailPorid_Usuario----------*/
        public List<string> Proc_listarEmailPorid_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarEmailPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id)).ToList();

                if (existencia.Count == 0)
                {
                    email.Add("Error");
                }
                else
                {
                    email.AddRange(existencia);
                }
                return email;
            }
        }

        public List<string> nombre_Completo = new List<string>();
        /*----------Proc_listarnombre_CompletoPorid_Usuario----------*/
        public List<string> Proc_listarnombre_CompletoPorid_Usuario(List<int> id) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                for (int i = 0; i < id.Count; i++)
                {
                    var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarnombre_CompletoPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id[i])).ToList();

                    nombre_Completo.AddRange(existencia);
                }
                return nombre_Completo;
            }
        }

        /*----------Proc_listarnombre_CompletoPorid_Usuario----------*/
        public string Proc_listarNombre_CompletoPorid_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarnombre_CompletoPorid_Usuario(id).FirstOrDefault();
            }
        }

        public List<byte[]> listarFotoUsuario = new List<byte[]>();
        /*----------Proc_listarFotoPorid_Usuario----------*/
        public List<byte[]> Proc_listarFotoPorid_Usuario(List<int> id)
        {
            using (var db = new VeterinariaEntities())
            {
                for (int i = 0; i < id.Count; i++)
                {
                    var existencia = db.Database.SqlQuery<byte[]>("EXEC Proc_listarFotoPorid_Usuario @id_Usuario", new SqlParameter("@id_Usuario", id[i])).ToList();

                    if (existencia.Count == 0)
                    {
                        listarFotoUsuario.AddRange(existencia);
                    }
                    else
                    {
                        listarFotoUsuario.AddRange(existencia);
                    }
                }
                return listarFotoUsuario;
            }
        }

        /*----------Proc_listarUnaFotoPorid_Usuario----------*/
        public List<byte[]> Proc_listarUnaFotoPorid_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<byte[]>("EXEC Proc_listarFotoPorid_Usuario @id_Usuario", new SqlParameter("@id_Usuario", id)).ToList();

                if (existencia.Count == 0)
                {
                    listarFotoUsuario.AddRange(existencia);
                }
                else
                {
                    listarFotoUsuario.AddRange(existencia);
                }

                return listarFotoUsuario;
            }
        }

        
        /*----------Proc_listarNombreCompletoAdmin----------*/
        public List<Proc_listarNombreCompletoAdmin_Result> Proc_listarNombreCompletoAdmin()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarNombreCompletoAdmin().ToList();
            }
        }

        /*----------Proc_listarFotoPorNombreUsuario----------*/
        public List<byte[]> Proc_listarFotoPorNombreUsuario(string nombre)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<byte[]>("EXEC Proc_listarFotoPorNombreUsuario @nombre_Completo", new SqlParameter("@nombre_Completo", nombre)).ToList();

                if (existencia.Count == 0)
                {
                    listarFotoUsuario.AddRange(existencia);
                }
                else
                {
                    listarFotoUsuario.AddRange(existencia);
                }

                return listarFotoUsuario;
            }
        }

        /*----------Proc_crearUsuario----------*/
        public void Proc_crearUsuario(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearUsuario(usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.foto, usuario.email, usuario.password);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarUsuario----------*/
        public void Proc_actualizarUsuario(Usuario usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_actualizarUsuario(usuario.id_Usuario, usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.foto, usuario.email, usuario.password);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarUsuario----------*/
        public void Proc_eliminarUsuario(int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_eliminarUsuario(id_Usuario);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Usuario----------*/


        /*----------Tabla Rol----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_crearRol----------*/
        public void Proc_crearRol(Rol rol) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearRol(rol.nombre);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol----------*/


        /*----------Tabla Rol_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRol_Usuario----------*/
        public List<Proc_listarRol_Usuario_Result> Proc_listarRol_Usuario() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarRol_Usuario().ToList();
            }
        }

        /*----------Proc_listarRol_UsuarioPorid_Usuario----------*/
        public Proc_listarRol_UsuarioPorid_Usuario_Result Proc_listarRol_UsuarioPorid_Usuario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarRol_UsuarioPorid_Usuario(id_Usuario).FirstOrDefault();
            }
        }

        /*----------Proc_listarid_RolPorid_Usuario----------*/

        public int Proc_listarid_RolPorid_Usuario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_RolPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id_Usuario)).FirstOrDefault();
            }
        }

        /*----------Proc_crearRol_Usuario----------*/
        public void Proc_crearRol_Usuario(int id_Rol, int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearRol_Usuario(id_Rol, id_Usuario);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarRol_Usuario----------*/
        public void Proc_actualizarRol_Usuario(int id_Rol, int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarRol_Usuario(id_Rol, id_Usuario);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarRol_Usuario----------*/
        public void Proc_eliminarRol_Usuario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarRol_Usuario(id_Usuario);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla Rol_Usuario----------*/


        /*----------Tabla Mascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarMascota----------*/
        public List<Proc_listarMascota_Result> Proc_listarMascota() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarMascota().ToList();
            }
        }

        /*----------Proc_listarMascotaPorid_Mascota----------*/
        public Proc_listarMascotaPorid_Mascota_Result Proc_listarMascotaPorid_Mascota(int id_Mascota) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarMascotaPorid_Mascota(id_Mascota).FirstOrDefault();
            }
        }

        public List<byte[]> listarFoto = new List<byte[]>();
        /*----------Proc_listarFotoPorid_Mascota----------*/
        public List<byte[]> Proc_listarFotoPorid_Mascota(List<int> id) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                for (int i = 0; i < id.Count; i++) 
                {
                    var existencia = db.Database.SqlQuery<byte[]>("EXEC Proc_listarFotoPorid_Mascota @id_Mascota", new SqlParameter("@id_Mascota", id[i])).ToList();

                    if (existencia.Count == 0) 
                    {
                        listarFoto.AddRange(existencia);
                    }
                    else 
                    {
                        listarFoto.AddRange(existencia);
                    }
                }
                return listarFoto;
            }
        }

        /*----------Proc_listarFotoPorid_Mascota----------*/
        public List<byte[]> Proc_listarUnaFotoPorid_Mascota(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<byte[]>("EXEC Proc_listarFotoPorid_Mascota @id_Mascota", new SqlParameter("@id_Mascota", id)).ToList();

                if (existencia.Count == 0)
                {
                    listarFoto.AddRange(existencia);
                }
                else
                {
                    listarFoto.AddRange(existencia);
                }
                
                return listarFoto;
            }
        }

        /*----------Proc_listarMascotaPorid_Usuario----------*/
        public Proc_listarMascotaPorid_Usuario_Result Proc_listarMascotaPorid_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarMascotaPorid_Usuario(id).FirstOrDefault();
            }
        }

        public List<string> mascota = new List<string>();
        /*----------Proc_listarNombre_MascotaPorid_Usuario----------*/
        public List<string> Proc_listarNombre_MascotaPorid_Usuario(int id) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarNombre_MascotaPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id)).ToList(); 
                
                if (existencia.Count == 0)
                {
                    mascota.Add("Aún no tienes una mascota");
                }
                else
                {
                    mascota.AddRange(existencia);
                }
                return mascota;
            }
        }

        public List<string> nombre_Mascota = new List<string>();
        /*----------Proc_listarNombre_MascotaPorid_Usuario----------*/
        public List<string> Proc_listarTodoNombre_MascotaPorid_Usuario(List<int> id)
        {
            using (var db = new VeterinariaEntities())
            {
                for (int i = 0; i < id.Count; i++) 
                {
                    var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarNombre_MascotaPorid_Usuario @id_Usuario",
                        new SqlParameter("@id_Usuario", id[i])).ToList();

                    if (existencia.Count == 0)
                    {
                        nombre_Mascota.Add("Aún no tienes una mascota");
                    }
                    else
                    {
                        nombre_Mascota.AddRange(existencia);
                    }
                }
                return nombre_Mascota;
            }
        }

        /*----------Proc_listarid_MascotaPornombre_Completo----------*/
        public int Proc_listarid_MascotaPornombre_Completo(string nombre) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_MascotaPornombre_Completo @nombre_Completo",
                    new SqlParameter("@nombre_Completo", nombre)).FirstOrDefault();
            }
        }

        /*----------Proc_crearMascota----------*/
        public void Proc_crearMascota(Mascota mascota) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearMascota(mascota.nombre_Completo, mascota.sexo, mascota.peso, mascota.foto, mascota.fecha_Ingreso.Replace("-", "/"), mascota.fecha_Ingreso.Replace("-", "/"));
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarMascota----------*/
        public void Proc_actualizarMascota(Mascota mascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarMascota(mascota.id_Mascota, mascota.nombre_Completo, mascota.sexo, mascota.peso, mascota.foto, mascota.fecha_Ingreso.Replace("-", "/"), mascota.fecha_Ingreso.Replace("-", "/"));
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarMascota----------*/
        public void Proc_eliminarMascota(int id_Mascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarMascota(id_Mascota);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Mascota----------*/


        /*----------Tabla Mascota_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarMascota_Usuario----------*/
        public List<Proc_listarMascota_Usuario_Result> Proc_listarMascota_Usuario() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarMascota_Usuario().ToList();
            }
        }

        /*----------Proc_listarMascota_UsuarioPorid_Mascota----------*/
        public Proc_listarMascota_UsuarioPorid_Mascota_Result Proc_listarMascota_UsuarioPorid_Mascota(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarMascota_UsuarioPorid_Mascota(id).FirstOrDefault();
            }
        }

        /*----------Proc_crearMascota_Usuario----------*/
        public void Proc_crearMascota_Usuario(Mascota_Usuario mascota_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearMascota_Usuario(mascota_Usuario.id_Mascota, mascota_Usuario.id_Usuario, mascota_Usuario.id_Tipo, mascota_Usuario.id_Raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarMascota_Usuario----------*/
        public void Proc_actualizarMascota_Usuario(Mascota_Usuario mascota_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarMascota_Usuario(mascota_Usuario.id_Mascota, mascota_Usuario.id_Usuario, mascota_Usuario.id_Tipo, mascota_Usuario.id_Raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarMascota_Usuario----------*/
        public void Proc_eliminarMascota_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarMascota_Usuario(id);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla Mascota_Usuario----------*/


        /*----------Tabla TipoMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarTipoMascota----------*/
        public List<Proc_listarTipoMascota_Result> Proc_listarTipoMascota() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarTipoMascota().ToList();
            }
        }

        /*----------Proc_listarTipoMascotaPorid_Tipo----------*/
        public Proc_listarTipoMascotaPorid_Tipo_Result Proc_listarTipoMascotaPorid_Tipo(int id_Tipo)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarTipoMascotaPorid_Tipo(id_Tipo).FirstOrDefault();
            }
        }

        public List<string> tipo = new List<string>();
        /*----------Proc_listarSoloTipoMascotaPorid_Tipo --> JSON----------*/
        public List<string> Proc_listarSoloTipoMascotaPorid_Tipo(List<int> id)
        {
            using (var db = new VeterinariaEntities())
            {
                for (int i = 0; i < id.Count; i++) 
                {
                    tipo.AddRange(db.Database.SqlQuery<string>("EXEC Proc_listarSoloTipoMascotaPorid_Tipo @id_Tipo", new SqlParameter("@id_Tipo", id[i])).ToList());
                }
                return tipo;
            }
        }

        /*----------Proc_crearTipoMascota----------*/
        public void Proc_crearTipoMascota(TipoMascota tipoMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearTipoMascota(tipoMascota.tipo);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarTipoMascota----------*/
        public void Proc_actualizarTipoMascota(TipoMascota tipoMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarTipoMascota(tipoMascota.id_Tipo, tipoMascota.tipo);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarTipoMascota----------*/
        public void Proc_eliminarTipoMascota(int id_Tipo)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarTipoMascota(id_Tipo);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla TipoMascota----------*/


        /*----------Tabla RazaMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRazaMascota----------*/
        public List<Proc_listarRazaMascota_Result> Proc_listarRazaMascota()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarRazaMascota().ToList();
            }
        }

        /*----------Proc_listarRazaMascotaPorid_Raza----------*/
        public Proc_listarRazaMascotaPorid_Raza_Result Proc_listarRazaMascotaPorid_Raza(int id_Raza)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarRazaMascotaPorid_Raza(id_Raza).FirstOrDefault();
            }
        }

        public List<string> raza = new List<string>();
        /*----------Proc_listarSoloRazaMascotaPorid_Raza----------*/
        public List<string> Proc_listarSoloRazaMascotaPorid_Raza(List<int> id) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                for (int i = 0; i < id.Count; i++) 
                {
                    raza.AddRange(db.Database.SqlQuery<string>("EXEC Proc_listarSoloRazaMascotaPorid_Raza @id_Raza", new SqlParameter("@id_Raza", id[i])).ToList());
                }
                return raza;
            }
        }

        /*----------Proc_crearRaza----------*/
        public void Proc_crearRazaMascota(RazaMascota razaMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearRazaMascota(razaMascota.raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarRazaMascota----------*/
        public void Proc_actualizarRazaMascota(RazaMascota razaMascota)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarRazaMascota(razaMascota.id_Raza, razaMascota.raza);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarRazaMascota----------*/
        public void Proc_eliminarRazaMascota(int id_Raza)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarRazaMascota(id_Raza);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla RazaMascota----------*/


        /*----------Tabla Cita----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarCita----------*/
        public List<Proc_listarCita_Result> Proc_listarCita() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarCita().ToList();
            }
        }

        /*----------Proc_listarCitaPorid_Cita----------*/
        public Proc_listarCitaPorid_Cita_Result Proc_listarCitaPorid_Cita(int id_Cita) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarCitaPorid_Cita(id_Cita).FirstOrDefault();
            }
        }

        public List<string> fecha_Cita = new List<string>();
        /*----------Proc_listarCitaPorfecha_Cita----------*/
        public List<string> Proc_listarCitaPorfecha_Cita(string fecha) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarCitaPorfecha_Cita @fecha_Cita",
                    new SqlParameter("@fecha_Cita", fecha)).ToList();

                if (existencia.Count == 0)
                {
                    fecha_Cita.Add("Aún no es el día de la cita o pasó");
                }
                else 
                {
                    fecha_Cita.AddRange(existencia);
                }
                return fecha_Cita;
            }
        }

        public List<string> servicio = new List<string>();
        /*----------Proc_listarid_UsuarioVeterinarioPorid_Usuario----------*/
        public List<string> Proc_listarservicioPorid_Usuario(int id_Usuario) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarservicioPorid_Usuario @id_Usuario",
                    new SqlParameter("@id_Usuario", id_Usuario)).ToList();

                if (existencia.Count == 0) 
                {
                    servicio.Add("Aún no tienes una cita");
                }
                else 
                {
                    servicio.AddRange(existencia);
                }
                return servicio;
            }
        }

        /*----------Proc_listarCitaPorid_Usuario----------*/
        public List<Proc_listarCitaPorid_Usuario_Result> Proc_listarCitaPorid_Usuario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarCitaPorid_Usuario(id_Usuario).ToList();
            }
        }

        /*----------Proc_listarTodaCitaPorfecha_Cita----------*/
        public List<Proc_listarTodaCitaPorfecha_Cita_Result> Proc_listarTodaCitaPorfecha_Cita(string fecha) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarTodaCitaPorfecha_Cita(fecha).ToList();
            }
        }

        /*----------Proc_listarCitaPorid_Usuario_id_UsuarioVeterinario----------*/
        public List<Proc_listarCitaPorid_Usuario_id_UsuarioVeterinario_Result> Proc_listarCitaPorid_Usuario_id_UsuarioVeterinario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarCitaPorid_Usuario_id_UsuarioVeterinario(id_Usuario).ToList();
            }
        }

        public List<string> servicio2 = new List<string>();
        /*----------Proc_listarservicioPorid_Usuario_id_UsuarioVeterinario----------*/
        public List<string> Proc_listarservicioPorid_Usuario_id_UsuarioVeterinario(int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<string>("EXEC Proc_listarservicioPorid_Usuario_id_UsuarioVeterinario @id_Usuario",
                    new SqlParameter("@id_Usuario", id_Usuario)).ToList();

                if (existencia.Count == 0)
                {
                    servicio2.Add("Aún no tienes una cita");
                }
                else
                {
                    servicio2.AddRange(existencia);
                }
                return servicio2;
            }
        }

        /*----------Proc_comprobarCantidadCita----------*/
        public int Proc_comprobarCantidadCita(string fecha_Cita) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<int>("EXEC Proc_comprobarCantidadCita @fecha_Cita",
                    new SqlParameter("@fecha_Cita", fecha_Cita)).FirstOrDefault();
            }
        }

        /*----------Proc_listarid_CitaPorMascota----------*/
        public int Proc_listarid_CitaPorMascota(string mascota) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<int>("EXEC Proc_listarid_CitaPorMascota @mascota",
                    new SqlParameter("@mascota", mascota)).FirstOrDefault();
            }
        }

        public List<bool> comprobar_Cita = new List<bool>();
        /*----------Proc_listarCitaPorfecha_Cita_id_Usuario----------*/
        public List<bool> Proc_listarCitaPorfecha_Cita_id_Usuario(string fecha, int id_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                var existencia = db.Database.SqlQuery<bool>("EXEC Proc_listarCitaPorfecha_Cita_id_Usuario @fecha_Cita, @id_Usuario",
                    new SqlParameter("@fecha_Cita", fecha), new SqlParameter("@id_Usuario", id_Usuario)).ToList();

                if (existencia.Contains(true))
                {
                    comprobar_Cita.Add(true);
                }
                else
                {
                    comprobar_Cita.Add(false);
                }
                return comprobar_Cita;
            }
        }

        /*----------Proc_actualizarCitaPorid_Cita----------*/
        public void Proc_actualizarCitaPorid_Cita(int id_Cita) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_actualizarCitaPorid_Cita(id_Cita);
                db.SaveChanges();
            }
        }

        /*----------Proc_crearCita----------*/
        public void Proc_crearCita(Cita cita) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearCita(cita.mascota, cita.servicio, cita.fecha_Cita.Replace("-", "/"), cita.fecha_Cita.Replace("-", "/"), cita.fecha_Cita.Replace("-", "/"), cita.comprobar_Cita);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarCita----------*/
        public void Proc_actualizarCita(Cita cita)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarCita(cita.id_Cita, cita.mascota, cita.servicio, cita.fecha_Cita.Replace("-", "/"), cita.fecha_Cita.Replace("-", "/"), cita.fecha_Cita.Replace("-", "/"), cita.comprobar_Cita);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarCita----------*/
        public void Proc_eliminarCita(int id_Cita)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarCita(id_Cita);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Cita----------*/


        /*----------Tabla Cita_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarCita_Usuario----------*/
        public List<Proc_listarCita_Usuario_Result> Proc_listarCita_Usuario()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarCita_Usuario().ToList();
            }
        }

        /*----------Proc_listarCita_UsuarioPorid_Cita----------*/
        public Proc_listarCita_UsuarioPorid_Cita_Result Proc_listarCita_UsuarioPorid_Cita(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarCita_UsuarioPorid_Cita(id).FirstOrDefault();
            }
        }

        /*----------Proc_crearCita_Usuario----------*/
        public void Proc_crearCita_Usuario(Cita_Usuario cita_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearCita_Usuario(cita_Usuario.id_Cita, cita_Usuario.id_Usuario, cita_Usuario.id_Mascota, cita_Usuario.id_UsuarioVeterinario);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarCita_Usuario----------*/
        public void Proc_actualizarCita_Usuario(Cita_Usuario cita_Usuario)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarCita_Usuario(cita_Usuario.id_Cita, cita_Usuario.id_Usuario, cita_Usuario.id_Mascota, cita_Usuario.id_UsuarioVeterinario);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarCita_Usuario----------*/
        public void Proc_eliminarCita_Usuario(int id)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarCita_Usuario(id);
                db.SaveChanges();
            }
        }

        /*----------Fin de los procedimientos almacenados de la tabla Cita_Usuario----------*/


        /*----------Tabla Servicio----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarServicio----------*/
        public List<Proc_listarServicio_Result> Proc_listarServicio() 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Proc_listarServicio().ToList();
            }
        }

        /*----------Proc_listarServicioPorid_Servicio----------*/
        public Proc_listarServicioPorid_Servicio_Result Proc_listarServicioPorid_Servicio(int id_Servicio)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarServicioPorid_Servicio(id_Servicio).FirstOrDefault();
            }
        }

        /*----------Proc_crearServicio----------*/
        public void Proc_crearServicio(Servicio servicio) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                db.Proc_crearServicio(servicio.descripcion);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarServicio----------*/
        public void Proc_actualizarServicio(Servicio servicio)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarServicio(servicio.id_Servicio, servicio.descripcion);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarServicio----------*/
        public void Proc_eliminarServicio(int id_Servicio)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarServicio(id_Servicio);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Servicio----------*/


        /*----------Tabla Consejo----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarConsejo----------*/
        public List<Proc_listarConsejo_Result> Proc_listarConsejo()
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarConsejo().ToList();
            }
        }

        /*----------Proc_listarConsejoPorid_Consejo----------*/
        public Proc_listarConsejoPorid_Consejo_Result Proc_listarConsejoPorid_Consejo(int id_Consejo)
        {
            using (var db = new VeterinariaEntities())
            {
                return db.Proc_listarConsejoPorid_Consejo(id_Consejo).FirstOrDefault();
            }
        }

        /*----------Proc_listarConsejoPorid_Tipo_id_Raza----------*/
        public List<string> Proc_listarConsejoPorid_Tipo_id_Raza(int id_Tipo, int id_Raza) 
        {
            using (var db = new VeterinariaEntities()) 
            {
                return db.Database.SqlQuery<string>("EXEC Proc_listarConsejoPorid_Tipo_id_Raza @id_Tipo, @id_Raza",
                    new SqlParameter("@id_Tipo", id_Tipo), new SqlParameter("@id_Raza", id_Raza)).ToList();
            }
        }

        /*----------Proc_crearConsejo----------*/
        public void Proc_crearConsejo(Consejo consejo)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_crearConsejo(consejo.id_Tipo, consejo.id_Raza, consejo.descripcion);
                db.SaveChanges();
            }
        }

        /*----------Proc_actualizarConsejo----------*/
        public void Proc_actualizarConsejo(Consejo consejo)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_actualizarConsejo(consejo.id_Consejo, consejo.id_Tipo, consejo.id_Raza, consejo.descripcion);
                db.SaveChanges();
            }
        }

        /*----------Proc_eliminarConsejo----------*/
        public void Proc_eliminarConsejo(int id_Consejo)
        {
            using (var db = new VeterinariaEntities())
            {
                db.Proc_eliminarConsejo(id_Consejo);
                db.SaveChanges();
            }
        }


        /*----------Fin de los procedimientos almacenados de la tabla Consejo----------*/
    }
}
