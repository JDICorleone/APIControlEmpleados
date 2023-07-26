
using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.EntityFrameworkCore;


namespace APIControlEmpleados.Models
{
    public class EmpleadosModel : IEmpleadosModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public EmpleadosModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }

        public List<Empleado> ConsultarEmpleados()
        {
            try
            {
                return _contexto.Empleado.FromSqlRaw("EXEC ConsultarEmpleados").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Empleados: " + ex.Message);
            }
        }


    }
}
