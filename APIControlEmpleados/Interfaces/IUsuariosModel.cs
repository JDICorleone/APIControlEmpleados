using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IUsuariosModel
    {

        public Usuario? ValidarUsuario(Usuario entidad);
    }
}
