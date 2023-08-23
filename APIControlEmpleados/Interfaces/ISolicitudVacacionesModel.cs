using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface ISolicitudVacacionesModel
    {
        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes(); 

        public int AgregarSolicitud(Solicitud_Vacaciones entidad);

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudesEmpleado(int id);

        public int CambiarEstado(int id_solicitud, string estado);
    }
}
