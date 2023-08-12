using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
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

        [HttpPost]
        [Route("AgregarPlanilla")]
        public IActionResult AgregarPlanilla(Planilla entidad)
        {
            try
            {
                try
                {
                    return Ok(_planillasModel.AgregarPlanilla(entidad));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
