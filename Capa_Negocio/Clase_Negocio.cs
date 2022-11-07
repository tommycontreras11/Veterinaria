using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class Clase_Negocio
    {
        Clase_Datos _Datos = new Clase_Datos();

        /*----------Tabla Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_loguearse----------*/
        public Proc_loguearse_Result Proc_loguearse(Usuario usuario)
        {
            return _Datos.Proc_loguearse(usuario);
        }

        /*----------Proc_listarUsuario----------*/
        public List<Proc_listarUsuario_Result> Proc_listarUsuario()
        {
            return _Datos.Proc_listarUsuario();
        }

        /*----------Proc_listarAdmin----------*/
        public List<Proc_listarAdmin_Result> Proc_listarAdmin()
        {
            return _Datos.Proc_listarAdmin();
        }

        /*----------Proc_listarUsuarioPorid_Usuario_Result----------*/
        public Proc_listarUsuarioPorid_Usuario_Result Proc_listarUsuarioPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarUsuarioPorid_Usuario(id_Usuario);
        }

        /*----------Proc_listarid_UsuarioPorEmail----------*/
        public int Proc_listarid_UsuarioPorEmail(string email)
        {
            return _Datos.Proc_listarid_UsuarioPorEmail(email);
        }

        /*----------Proc_listarEmailPorid_Usuario----------*/
        public List<string> Proc_listarEmailPorid_Usuario(int id)
        {
            return _Datos.Proc_listarEmailPorid_Usuario(id);
        }

        /*----------Proc_listarnombre_CompletoPorid_Usuario----------*/
        public List<string> Proc_listarnombre_CompletoPorid_Usuario(List<int> id)
        {
            return _Datos.Proc_listarnombre_CompletoPorid_Usuario(id);
        }

        /*----------Proc_listarnombre_CompletoPorid_Usuario----------*/
        public string Proc_listarnombre_CompletoPorid_Usuario(int id)
        {
            return _Datos.Proc_listarnombre_CompletoPorid_Usuario(id);
        }

        /*----------Proc_crearUsuario----------*/
        public void Proc_crearUsuario(Usuario usuario)
        {
            _Datos.Proc_crearUsuario(usuario);
        }

        /*----------Proc_actualizarUsuario----------*/
        public void Proc_actualizarUsuario(Usuario usuario)
        {
            _Datos.Proc_actualizarUsuario(usuario);
        }

        /*----------Proc_eliminarUsuario----------*/
        public void Proc_eliminarUsuario(int id_Usuario)
        {
            _Datos.Proc_eliminarUsuario(id_Usuario);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Usuario----------*/


        /*----------Tabla Rol----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_crearRol----------*/
        public void Proc_crearRol(Rol rol)
        {
            _Datos.Proc_crearRol(rol);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol----------*/


        /*----------Tabla Rol_Usuario----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRol_Usuario----------*/
        public List<Proc_listarRol_Usuario_Result> Proc_listarRol_Usuario()
        {
            return _Datos.Proc_listarRol_Usuario();
        }

        /*----------Proc_listarRol_UsuarioPorid_Usuario----------*/
        public Proc_listarRol_UsuarioPorid_Usuario_Result Proc_listarRol_UsuarioPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarRol_UsuarioPorid_Usuario(id_Usuario);
        }

        /*----------Proc_listarid_RolPorid_Usuario----------*/

        public int Proc_listarid_RolPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarid_RolPorid_Usuario(id_Usuario);
        }

        /*----------Proc_crearRol_Usuario----------*/
        public void Proc_crearRol_Usuario(int id_Rol, int id_Usuario)
        {
            _Datos.Proc_crearRol_Usuario(id_Rol, id_Usuario);
        }

        /*----------Proc_actualizarRol_Usuario----------*/
        public void Proc_actualizarRol_Usuario(int id_Rol, int id_Usuario)
        {
            _Datos.Proc_actualizarRol_Usuario(id_Rol, id_Usuario);
        }

        /*----------Proc_eliminarRol_Usuario----------*/
        public void Proc_eliminarRol_Usuario(int id_Usuario)
        {
            _Datos.Proc_eliminarRol_Usuario(id_Usuario);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Rol_Usuario----------*/


        /*----------Tabla Mascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarMascota----------*/
        public List<Proc_listarMascota_Result> Proc_listarMascota()
        {
            return _Datos.Proc_listarMascota();
        }

        /*----------Proc_listarMascotaPorid_Mascota----------*/
        public Proc_listarMascotaPorid_Mascota_Result Proc_listarMascotaPorid_Mascota(int id_Mascota)
        {
            return _Datos.Proc_listarMascotaPorid_Mascota(id_Mascota);
        }

        /*----------Proc_listarFotoPorid_Mascota----------*/
        public List<byte[]> Proc_listarFotoPorid_Mascota(List<int> id)
        {
            return _Datos.Proc_listarFotoPorid_Mascota(id);
        }

        /*----------Proc_listarFotoPorid_Mascota----------*/
        public List<byte[]> Proc_listarUnaFotoPorid_Mascota(int id)
        {
            return _Datos.Proc_listarUnaFotoPorid_Mascota(id);
        }

        /*----------Proc_listarMascotaPorid_Usuario----------*/
        public Proc_listarMascotaPorid_Usuario_Result Proc_listarMascotaPorid_Usuario(int id)
        {
            return _Datos.Proc_listarMascotaPorid_Usuario(id);
        }

        /*----------Proc_listarSoloTipoMascotaPorid_Tipo --> JSON----------*/
        public List<string> Proc_listarSoloTipoMascotaPorid_Tipo(List<int> id)
        {
            return _Datos.Proc_listarSoloTipoMascotaPorid_Tipo(id);
        }

        /*----------Proc_listarMascotaid_Usuario----------*/
        public List<string> Proc_listarNombre_MascotaPorid_Usuario(int id)
        {
            return _Datos.Proc_listarNombre_MascotaPorid_Usuario(id);
        }

        /*----------Proc_listarNombre_MascotaPorid_Usuario----------*/
        public List<string> Proc_listarTodoNombre_MascotaPorid_Usuario(List<int> id)
        {
            return _Datos.Proc_listarTodoNombre_MascotaPorid_Usuario(id);
        }

        /*----------Proc_listarid_MascotaPornombre_Completo----------*/
        public int Proc_listarid_MascotaPornombre_Completo(string nombre)
        {
            return _Datos.Proc_listarid_MascotaPornombre_Completo(nombre);
        }

        /*----------Proc_crearMascota----------*/
        public void Proc_crearMascota(Mascota mascota)
        {
            _Datos.Proc_crearMascota(mascota);
        }

        /*----------Proc_actualizarMascota----------*/
        public void Proc_actualizarMascota(Mascota mascota)
        {
            _Datos.Proc_actualizarMascota(mascota);
        }

        /*----------Proc_eliminarMascota----------*/
        public void Proc_eliminarMascota(int id_Mascota)
        {
            _Datos.Proc_eliminarMascota(id_Mascota);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Mascota----------*/


        /*----------Tabla TipoMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarTipoMascota----------*/
        public List<Proc_listarTipoMascota_Result> Proc_listarTipoMascota()
        {
            return _Datos.Proc_listarTipoMascota();
        }

        /*----------Proc_listarTipoMascotaPorid_Tipo----------*/
        public Proc_listarTipoMascotaPorid_Tipo_Result Proc_listarTipoMascotaPorid_Tipo(int id_Tipo)
        {
            return _Datos.Proc_listarTipoMascotaPorid_Tipo(id_Tipo);
        }

        /*----------Proc_crearTipoMascota----------*/
        public void Proc_crearTipoMascota(TipoMascota tipoMascota)
        {
            _Datos.Proc_crearTipoMascota(tipoMascota);
        }

        /*----------Proc_actualizarTipoMascota----------*/
        public void Proc_actualizarTipoMascota(TipoMascota tipoMascota)
        {
            _Datos.Proc_actualizarTipoMascota(tipoMascota);
        }

        /*----------Proc_eliminarTipoMascota----------*/
        public void Proc_eliminarTipoMascota(int id_Tipo)
        {
            _Datos.Proc_eliminarTipoMascota(id_Tipo);
        }

        /*----------Fin de los procedimientos almacenados de la tabla TipoAnimal----------*/


        /*----------Tabla RazaMascota----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarRazaMascota----------*/
        public List<Proc_listarRazaMascota_Result> Proc_listarRazaMascota()
        {
            return _Datos.Proc_listarRazaMascota();
        }

        /*----------Proc_listarRazaMascotaPorid_Raza----------*/
        public Proc_listarRazaMascotaPorid_Raza_Result Proc_listarRazaMascotaPorid_Raza(int id_Raza)
        {
            return _Datos.Proc_listarRazaMascotaPorid_Raza(id_Raza);
        }

        /*----------Proc_listarSoloRazaMascotaPorid_Raza----------*/
        public List<string> Proc_listarSoloRazaMascotaPorid_Raza(List<int> id)
        {
            return _Datos.Proc_listarSoloRazaMascotaPorid_Raza(id);
        }

        /*----------Proc_crearRazaMascota----------*/
        public void Proc_crearRazaMascota(RazaMascota razaMascota)
        {
            _Datos.Proc_crearRazaMascota(razaMascota);
        }

        /*----------Proc_actualizarRazaMascota----------*/
        public void Proc_actualizarRazaMascota(RazaMascota razaMascota)
        {
            _Datos.Proc_actualizarRazaMascota(razaMascota);
        }

        /*----------Proc_eliminarRazaMascota----------*/
        public void Proc_eliminarRazaMascota(int id_Raza)
        {
            _Datos.Proc_eliminarRazaMascota(id_Raza);
        }

        /*----------Fin de los procedimientos almacenados de la tabla RazaMascota----------*/


        /*----------Tabla Cita----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarCita----------*/
        public List<Proc_listarCita_Result> Proc_listarCita()
        {
            return _Datos.Proc_listarCita();
        }

        /*----------Proc_listarCitaPorid_Cita----------*/
        public Proc_listarCitaPorid_Cita_Result Proc_listarCitaPorid_Cita(int id_Cita)
        {
            return _Datos.Proc_listarCitaPorid_Cita(id_Cita);
        }

        /*----------Proc_listarCitaPorfecha_Cita----------*/
        public List<string> Proc_listarCitaPorfecha_Cita(string fecha)
        {
            return _Datos.Proc_listarCitaPorfecha_Cita(fecha);
        }

        /*----------Proc_listarservicioPorid_Usuario----------*/
        public List<string> Proc_listarservicioPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarservicioPorid_Usuario(id_Usuario);
        }

        /*----------Proc_listarCitaPorid_Usuario----------*/
        public List<Proc_listarCitaPorid_Usuario_Result> Proc_listarCitaPorid_Usuario(int id_Usuario)
        {
            return _Datos.Proc_listarCitaPorid_Usuario(id_Usuario);
        }

        /*----------Proc_listarTodaCitaPorfecha_Cita----------*/
        public List<Proc_listarTodaCitaPorfecha_Cita_Result> Proc_listarTodaCitaPorfecha_Cita(string fecha)
        {
            return _Datos.Proc_listarTodaCitaPorfecha_Cita(fecha);
        }

        /*----------Proc_actualizarCitaPorid_Cita----------*/
        public void Proc_actualizarCitaPorid_Cita(int id_Cita)
        {
            _Datos.Proc_actualizarCitaPorid_Cita(id_Cita);
        }

        /*----------Proc_crearCita----------*/
        public void Proc_crearCita(Cita cita)
        {
            _Datos.Proc_crearCita(cita);
        }

        /*----------Proc_actualizarCita----------*/
        public void Proc_actualizarCita(Cita cita)
        {
            _Datos.Proc_actualizarCita(cita);
        }

        /*----------Proc_eliminarCita----------*/
        public void Proc_eliminarCita(int id_Cita)
        {
            _Datos.Proc_eliminarCita(id_Cita);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Cita----------*/


        /*----------Tabla Servicio----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarServicio----------*/
        public List<Proc_listarServicio_Result> Proc_listarServicio()
        {
            return _Datos.Proc_listarServicio();
        }

        /*----------Proc_listarServicioPorid_Servicio----------*/
        public Proc_listarServicioPorid_Servicio_Result Proc_listarServicioPorid_Servicio(int id_Servicio)
        {
            return _Datos.Proc_listarServicioPorid_Servicio(id_Servicio);
        }

        /*----------Proc_crearServicio----------*/
        public void Proc_crearServicio(Servicio servicio)
        {
            _Datos.Proc_crearServicio(servicio);
        }

        /*----------Proc_actualizarServicio----------*/
        public void Proc_actualizarServicio(Servicio servicio)
        {
            _Datos.Proc_actualizarServicio(servicio);
        }

        /*----------Proc_eliminarServicio----------*/
        public void Proc_eliminarServicio(int id_Servicio)
        {
            _Datos.Proc_eliminarServicio(id_Servicio);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Servicio----------*/


        /*----------Tabla Consejo----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarConsejo----------*/
        public List<Proc_listarConsejo_Result> Proc_listarConsejo()
        {
            return _Datos.Proc_listarConsejo();
        }

        /*----------Proc_listarConsejoPorid_Consejo----------*/
        public Proc_listarConsejoPorid_Consejo_Result Proc_listarConsejoPorid_Consejo(int id_Consejo)
        {
            return _Datos.Proc_listarConsejoPorid_Consejo(id_Consejo);
        }

        /*----------Proc_crearConsejo----------*/
        public void Proc_crearConsejo(Consejo consejo)
        {
            _Datos.Proc_crearConsejo(consejo);
        }

        /*----------Proc_actualizarConsejo----------*/
        public void Proc_actualizarConsejo(Consejo consejo)
        {
            _Datos.Proc_actualizarConsejo(consejo);
        }

        /*----------Proc_eliminarConsejo----------*/
        public void Proc_eliminarConsejo(int id_Consejo)
        {
            _Datos.Proc_eliminarConsejo(id_Consejo);
        }


        /*----------Fin de los procedimientos almacenados de la tabla Consejo----------*/


        /*----------Tabla Chat----------*/


        /*----------Procedimientos almacenados----------*/

        /*----------Proc_listarChat----------*/
        public List<Proc_listarChat_Result> Proc_listarChat()
        {
            return _Datos.Proc_listarChat();
        }

        /*----------Proc_listarChatPorid_Usuario----------*/
        public List<Proc_listarChatPorid_Usuario_Result> Proc_listarChatPorid_Usuario(int id_Usuario, int id_UsuarioRespuesta)
        {
            return _Datos.Proc_listarChatPorid_Usuario(id_Usuario, id_UsuarioRespuesta);
        }

        /*----------Proc_listarcomentarioPorid_Usuario----------*/
        public List<string> Proc_listarcomentarioPorid_Usuario(int id_Usuario, int id_UsuarioVeterinario)
        {
            return _Datos.Proc_listarcomentarioPorid_Usuario(id_Usuario, id_UsuarioVeterinario);
        }

        /*----------Proc_crearChat----------*/
        public void Proc_crearChat(Chat chat)
        {
            _Datos.Proc_crearChat(chat);
        }

        ///*----------Proc_actualizarConsejo----------*/
        //public void Proc_actualizarConsejo_Mascota(Consejo_Mascota consejo_Mascota)
        //{
        //    _Datos.Proc_actualizarConsejo_Mascota(consejo_Mascota);
        //}

        ///*----------Proc_eliminarConsejo----------*/
        //public void Proc_eliminarConsejo_Mascota(int id_Consejo_Mascota)
        //{
        //    _Datos.Proc_eliminarConsejo_Mascota(id_Consejo_Mascota);
        //}
    }
}

