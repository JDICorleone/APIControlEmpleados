using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIControlEmpleados.Models
{
    public class PlanillasModel : IPlanillasModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public PlanillasModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }

        public List<Planilla> ConsultarPlanillas()
        {
            try
            {
                return _contexto.Planilla.FromSqlRaw("EXEC ConsultarPlanillas").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Empleados: " + ex.Message);
            }
        }
    }
}
