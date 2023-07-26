using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IUsuariosModel
    {
        public void EnviarCorreo(string Destinatario, string Asunto, string Mensaje);
        public Usuario? ValidarUsuario(Usuario entidad);
        public Usuario BuscarCorreo(string correoUsuario);

        public void RecuperarContrasenna(Usuario entidad);
    }
}
