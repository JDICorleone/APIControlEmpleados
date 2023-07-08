
using APIControlEmpleados.Entities;
using APIControlEmpleados.Models;
using Microsoft.EntityFrameworkCore;


namespace APIControlEmpleados.Models
{
    public class UsuariosModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public UsuariosModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }

        public Usuarios? ValidarUsuario(Usuarios entidad)
        {
            try
            {
                return _contexto.Usuario.FirstOrDefault(u =>
               u.CORREO == entidad.CORREO &&
               u.CONTRASEÑA == entidad.CONTRASEÑA);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo UsuariosModel: " + ex.Message);
            }

        }

        public List<Usuarios> ConsultarUsuarios()
        {
            try { return _contexto.Usuario.ToList(); }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo UsuariosModel: " + ex.Message);
            }

        }


    }
}
