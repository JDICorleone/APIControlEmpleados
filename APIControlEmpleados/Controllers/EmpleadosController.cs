using Microsoft.AspNetCore.Mvc;
using APIControlEmpleados.Models;
using APIControlEmpleados.Interfaces;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosModel _empleadosModel;
        public EmpleadosController(IEmpleadosModel empleadosModel)
        {
            _empleadosModel = empleadosModel;
        }

        [HttpGet]
        [Route("ConsultarEmpleados")]
        public IActionResult ConsultarEmpleados()
        {
            try
            {
                var resultado = _empleadosModel.ConsultarEmpleados();

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
