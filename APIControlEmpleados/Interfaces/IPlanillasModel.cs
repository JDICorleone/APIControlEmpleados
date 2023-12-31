﻿using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{

    public interface IPlanillasModel
    {
        public List<ConsultarPlanillas>? ConsultarPlanillas();
        public int AgregarPlanilla(Planilla entidad);
        public int EditarPlanilla(Planilla entidad);
        public List<Planilla> ConsultarPlanillas2();
        public List<ConsultarPlanillas>? ConsultarPlanillasEmpleado(int id);
    }
}
