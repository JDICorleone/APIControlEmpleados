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
                               join em in _contexto.Empleado on sv.ID_EMPLEADO equals em.ID_EMPLEADO
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

        public int AgregarSolicitud(Solicitud_Vacaciones entidad) {
            try
            {
                Solicitud_Vacaciones nuevaSolicitud = new Solicitud_Vacaciones
                {
                    ASUNTO = entidad.ASUNTO,
                    DESCRIPCION = entidad.DESCRIPCION,
                    TIPO_VACACIONES = entidad.TIPO_VACACIONES,
                    FECHA_INICIO = entidad.FECHA_INICIO,
                    FECHA_FINAL = entidad.FECHA_FINAL,
                    CANTIDAD_DIAS = entidad.CANTIDAD_DIAS,
                    ESTADO = entidad.ESTADO,
                    ID_EMPLEADO = entidad.ID_EMPLEADO,
                };

                _contexto.Solicitud_Vacaciones.Add(nuevaSolicitud);
                _contexto.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Solicitud de Vacaciones: " + ex.Message);

            }
        }

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudesEmpleado(int id)
        {

            try
            {
                var consulta =
                               from sv in _contexto.Solicitud_Vacaciones
                               join em in _contexto.Empleado on sv.ID_EMPLEADO equals em.ID_EMPLEADO
                               where sv.ID_EMPLEADO == id
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

        public int CambiarEstado(int id_solicitud, string estado)
        {
            try
            {
                Solicitud_Vacaciones solicitudExistente = _contexto.Solicitud_Vacaciones.Find(id_solicitud);
                if (solicitudExistente == null)
                {
                    return 0;
                }
                solicitudExistente.ESTADO = estado;

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
