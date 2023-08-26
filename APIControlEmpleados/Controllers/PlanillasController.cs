using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanillasController : ControllerBase
    {
        private readonly IPlanillasModel _planillasModel;

        public PlanillasController(IPlanillasModel planillasModel)
        {
            _planillasModel = planillasModel;
        }

        [HttpGet]
        [Route("ConsultarPlanillas")]
        public IActionResult ConsultarPlanillas()
        {
            try
            {
                var resultado = _planillasModel.ConsultarPlanillas();

                if (resultado == null)
                    return NotFound();
                else
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ConsultarPlanillas2")]
        public IActionResult ConsultarPlanillas2()
        {
            try
            {
                var resultado = _planillasModel.ConsultarPlanillas2();

                if (resultado.Count == 0)
                    return NotFound();
                else
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarPlanilla")]
        public IActionResult AgregarPlanilla(Planilla entidad)
        {

            try
            {
                var resultado = _planillasModel.AgregarPlanilla(entidad);

                if (resultado != 0)
                {
                    return Ok(resultado);

                }
                else
                {
                    return BadRequest();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("EditarPlanilla")]
        public IActionResult EditarPlanilla(Planilla entidad)
        {
            try
            {
                var resultado = _planillasModel.EditarPlanilla(entidad);

                if (resultado != 0)
                {
                    return Ok(resultado);

                }
                else
                {
                    return BadRequest();

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //Nuevo:
        [HttpGet]
        [Route("ConsultarPlanillasEmpleado")]
        public IActionResult ConsultarPlanillasEmpleado(int id)
        {
            try
            {
                var resultado = _planillasModel.ConsultarPlanillasEmpleado(id);

                if (resultado == null)
                    return NotFound();
                else
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
