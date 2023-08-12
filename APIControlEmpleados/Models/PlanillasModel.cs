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
        public List<Planilla>? ConsultarPlanillas()
        {
            try
            {
                return _contexto.Planilla.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Planilla: " + ex.Message);
            }
        }

        public int AgregarPlanilla(Planilla planilla)
        {
            try
            {
                _contexto.Planilla.Add(planilla);
                _contexto.SaveChanges();

                return 1;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Ocurrió un error al agregar la planilla");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
