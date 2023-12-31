﻿using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIControlEmpleados.Models
{
    public class PlanillasModel : IPlanillasModel
    {
        private readonly ControlEmpleadosContext _contexto;

        public PlanillasModel(ControlEmpleadosContext contexto)
        {
            _contexto = contexto;
        }
        public List<ConsultarPlanillas>? ConsultarPlanillas()
        {
            try
            {
                var consulta = from p in _contexto.Planilla
                               join e in _contexto.Empleado on p.ID_EMPLEADO equals e.ID_EMPLEADO
                               select new ConsultarPlanillas
                               {
                                   ID_PLANILLA = p.ID_PLANILLA,
                                   FECHA = p.FECHA,
                                   ID_EMPLEADO = e.ID_EMPLEADO,
                                   NOMBRE = e.NOMBRE,
                                   PRIMER_APELLIDO = e.PRIMER_APELLIDO,
                                   SEGUNDO_APELLIDO = e.SEGUNDO_APELLIDO,
                                   PAGO_POR_HORA = e.PAGO_POR_HORA,
                                   HORAS_EXTRAS = p.HORAS_EXTRAS,
                                   DEDUCCIONES = p.DEDUCCIONES,
                                   SALARIO_NETO = p.SALARIO_NETO
                               };

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Planillas: " + ex.Message);
            }
        }
        public List<Planilla> ConsultarPlanillas2()
        {
            try
            {
                var consulta = from p in _contexto.Planilla
                               select new Planilla
                               {
                                   ID_PLANILLA = p.ID_PLANILLA,
                                   FECHA = p.FECHA,
                                   ID_EMPLEADO = p.ID_EMPLEADO,
                                   HORAS_EXTRAS = p.HORAS_EXTRAS,
                                   DEDUCCIONES = p.DEDUCCIONES,
                                   SALARIO_NETO = p.SALARIO_NETO
                               };

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Planillas: " + ex.Message);
            }
        }

        public int AgregarPlanilla(Planilla planilla)
        {
            try
            {
                Planilla nuevaPlanilla = new Planilla
                {
                    FECHA = planilla.FECHA,
                    ID_EMPLEADO = planilla.ID_EMPLEADO,
                    HORAS_EXTRAS = planilla.HORAS_EXTRAS,
                    DEDUCCIONES = planilla.DEDUCCIONES,
                    SALARIO_NETO = planilla.SALARIO_NETO
                };

                _contexto.Planilla.Add(nuevaPlanilla);
                _contexto.SaveChanges();

                return 1;
            }
            catch (DbUpdateException ex)
            {

                throw new Exception("Ocurrió un error interno en el modelo Planillas: " + ex.Message);
            }
        }

        public int EditarPlanilla(Planilla entidad)
        {
            try
            {
                Planilla planillaExistente = _contexto.Planilla.Find(entidad.ID_PLANILLA);

                if (planillaExistente == null)
                {
                    return 0;
                }

                planillaExistente.FECHA = entidad.FECHA;
                planillaExistente.ID_EMPLEADO = entidad.ID_EMPLEADO;
                planillaExistente.HORAS_EXTRAS = entidad.HORAS_EXTRAS;
                planillaExistente.DEDUCCIONES = entidad.DEDUCCIONES;
                planillaExistente.SALARIO_NETO = entidad.SALARIO_NETO;

                _contexto.SaveChanges();

                return 1;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Planillas: " + ex.Message);
            }
        }

        //Nuevo
        public List<ConsultarPlanillas>? ConsultarPlanillasEmpleado(int id)
        {
            try
            {
                var consulta = from p in _contexto.Planilla
                               join e in _contexto.Empleado on p.ID_EMPLEADO equals e.ID_EMPLEADO
                               where p.ID_EMPLEADO == id
                               select new ConsultarPlanillas
                               {
                                   ID_PLANILLA = p.ID_PLANILLA,
                                   FECHA = p.FECHA,
                                   ID_EMPLEADO = e.ID_EMPLEADO,
                                   NOMBRE = e.NOMBRE,
                                   PRIMER_APELLIDO = e.PRIMER_APELLIDO,
                                   SEGUNDO_APELLIDO = e.SEGUNDO_APELLIDO,
                                   PAGO_POR_HORA = e.PAGO_POR_HORA,
                                   HORAS_EXTRAS = p.HORAS_EXTRAS,
                                   DEDUCCIONES = p.DEDUCCIONES,
                                   SALARIO_NETO = p.SALARIO_NETO
                               };

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno en el modelo Planillas: " + ex.Message);
            }
        }

    }
}
