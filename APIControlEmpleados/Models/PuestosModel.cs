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
                Console.WriteLine("Ocurrió un error al agregar el puesto:");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public int EditarPuesto(Puestos puestos) {
            try
            {
                Puestos puestoExistente = _contexto.Puestos.Find(puestos.ID_PUESTO);
                if (puestoExistente == null)
                {
                    return 0;
                }
                puestoExistente.NOMBRE_PUESTO = puestos.NOMBRE_PUESTO;

                _contexto.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo de Puestos: " + ex.Message);
            }
        }
    }
}
