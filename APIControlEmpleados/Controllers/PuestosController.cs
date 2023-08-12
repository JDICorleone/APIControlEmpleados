using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly IPuestosModel _puestosModel;

        public PuestosController(IPuestosModel puestosModel)
        {
            _puestosModel = puestosModel;
        }

        [HttpGet]
        [Route("ConsultarPuestos")]
        public IActionResult ConsultarPuestos()
        {
            try
            {
                var resultado = _puestosModel.ConsultarPuestos();

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
        [Route("AgregarPuesto")]
        public IActionResult AgregarPuesto(Puestos entidad)
        {
            try
            {
                try
                {
                    return Ok(_puestosModel.AgregarPuesto(entidad));
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
