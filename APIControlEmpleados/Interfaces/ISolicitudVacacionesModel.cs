using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface ISolicitudVacacionesModel
    {
        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes();

        public List<Solicitud_Vacaciones>? ConsultarSolicitudes2();

        public int AgregarSolicitud(Solicitud_Vacaciones entidad);

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudesEmpleado(int id);

        public int CambiarEstado(Solicitud_Vacaciones solicitud);
    }
}
