using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;

namespace APIControlEmpleados.Models
{
    public class SolicitudVacacionesModel : ISolicitudVacacionesModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public SolicitudVacacionesModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }
        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes() {

            try
            {
                var consulta =
                               from sv in _contexto.Solicitud_Vacaciones
                               join em in _contexto.Empleado on sv.ID_SOLICITUD_VACACIONES equals em.ID_EMPLEADO
                               select new ConsultarSolicitudVacaciones
                               {
                                   ID_SOLICITUD_VACACIONES = sv.ID_SOLICITUD_VACACIONES,
                                   ASUNTO = sv.ASUNTO,
                                   DESCRIPCION = sv.DESCRIPCION,
                                   TIPO_VACACIONES = sv.TIPO_VACACIONES,
                                   FECHA_INICIO = sv.FECHA_INICIO,
                                   FECHA_FINAL = sv.FECHA_FINAL,
                                   ESTADO = sv.ESTADO,
                                   NOMBRE = em.NOMBRE,
                                   PRIMER_APELLIDO = em.PRIMER_APELLIDO,
                                   SEGUNDO_APELLIDO = em.SEGUNDO_APELLIDO,
                                   CEDULA = em.CEDULA,
                                   VACACIONES_DISPONIBLES = em.VACACIONES_DISPONIBLES,
                               };

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Solicitud de : " + ex.Message);

            }
        }
    }
}
