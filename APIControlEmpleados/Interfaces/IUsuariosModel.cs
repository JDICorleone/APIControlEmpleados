using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IUsuariosModel
    {
        public void EnviarCorreo(string Destinatario, string Asunto, string Mensaje);
        public Usuario? ValidarUsuario(Usuario entidad);
        public Usuario BuscarCorreo(string correoUsuario);

        public List<ConsultarUsuarios> ConsultarUsuarios();
        public int RecuperarContrasenna(Usuario entidad);

        public int AgregarUsuario(Usuario entidad);

        public int EditarUsuario(Usuario entidad);

        public List<Usuario> ConsultarUsuarios2();

        public bool CorreoExiste(Usuario entidad);
    }
}
