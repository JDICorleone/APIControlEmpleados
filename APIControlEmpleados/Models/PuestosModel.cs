using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIControlEmpleados.Models
{
    public class PuestosModel : IPuestosModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public PuestosModel(ControlEmpleadosContext contexto) {
            _contexto = contexto;
        }
        public List<Puestos>? ConsultarPuestos()
        {
            try {
                return _contexto.Puestos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Puestos: " + ex.Message);
            }
        }

        public int AgregarPuesto(Puestos puestos) {
            try
            {
                _contexto.Puestos.Add(puestos);
                _contexto.SaveChanges();

                return 1;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Ocurrió un error al agregar el usuario:");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
