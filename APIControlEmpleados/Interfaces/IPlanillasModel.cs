﻿using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IPlanillasModel
    {
        public List<Planilla> ConsultarPlanillas();
    }
}
