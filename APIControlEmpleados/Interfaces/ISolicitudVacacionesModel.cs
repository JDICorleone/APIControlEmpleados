﻿using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface ISolicitudVacacionesModel
    {
        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes();
    }
}
