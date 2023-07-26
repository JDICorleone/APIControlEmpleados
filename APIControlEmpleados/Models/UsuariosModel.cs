using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;

namespace APIControlEmpleados.Models
{
    public class UsuariosModel : IUsuariosModel
    {


        private readonly ControlEmpleadosContext _contexto;

        public UsuariosModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }

        public Usuario? ValidarUsuario(Usuario entidad)
        {
            try
            {
                return _contexto.Usuario.FirstOrDefault(u =>
               u.CORREO == entidad.CORREO &&
               u.PASSWORD == entidad.PASSWORD);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Empleados: " + ex.Message);
            }

        }

    }
}
