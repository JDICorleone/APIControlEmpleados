﻿using APIControlEmpleados.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanillaController : ControllerBase
    {
        private readonly IPlanillasModel _planillasModel;
        public PlanillaController(IPlanillasModel planillasModel)
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
    }
}
