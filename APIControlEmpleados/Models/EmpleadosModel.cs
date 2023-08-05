
using APIControlEmpleados.Consults;
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

        public List<ConsultarEmpleados> ConsultarEmpleados()
        {
            var consulta = from em in _contexto.Empleado
                           join h in _contexto.Horarios on em.ID_HORARIO equals h.ID_HORARIO
                           join pp in _contexto.Periodo_Pago on em.ID_PERIODO equals pp.ID_PERIODO
                           join e in _contexto.Estado on em.ID_ESTADO equals e.ID_ESTADO
                           join pu in _contexto.Puestos on em.ID_PUESTO equals pu.ID_PUESTO
                           select new ConsultarEmpleados
                           {
                               ID_EMPLEADO = em.ID_EMPLEADO,
                               ID_USUARIO = em.ID_USUARIO,
                               NOMBRE = em.NOMBRE,
                               PRIMER_APELLIDO = em.PRIMER_APELLIDO,
                               SEGUNDO_APELLIDO = em.SEGUNDO_APELLIDO,
                               CEDULA = em.CEDULA,
                               HORARIO = h.HORARIO,
                               PAGO_POR_HORA = em.PAGO_POR_HORA,
                               PERIODO_DE_PAGO = pp.PERIODO_DE_PAGO,
                               VACACIONES_DISPONIBLES = em.VACACIONES_DISPONIBLES,
                               FECHA_DE_INGRESO = em.FECHA_DE_INGRESO,
                               ESTADO = e.ESTADO,
                               NOMBRE_PUESTO = pu.NOMBRE_PUESTO
                           };

            return consulta.ToList();
        }

        public int AgregarEmpleado(Empleado entidad)
        {
            try
            {
                Empleado nuevoEmpleado = new Empleado
                {
                    NOMBRE = entidad.NOMBRE,
                    PRIMER_APELLIDO = entidad.PRIMER_APELLIDO,
                    SEGUNDO_APELLIDO = entidad.SEGUNDO_APELLIDO,
                    CEDULA = entidad.CEDULA,
                    PAGO_POR_HORA = entidad.PAGO_POR_HORA,
                    VACACIONES_DISPONIBLES = entidad.VACACIONES_DISPONIBLES,
                    FECHA_DE_INGRESO = entidad.FECHA_DE_INGRESO,
                    ID_HORARIO = entidad.ID_HORARIO,
                    ID_PERIODO = entidad.ID_PERIODO,
                    ID_PUESTO = entidad.ID_PUESTO,
                    ID_ESTADO = entidad.ID_ESTADO,
                    ID_USUARIO = entidad.ID_USUARIO
                };

                _contexto.Empleado.Add(nuevoEmpleado);
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
