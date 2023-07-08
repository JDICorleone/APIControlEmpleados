using Microsoft.AspNetCore.Mvc;
using APIControlEmpleados.Models;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosModel _usuariosModel;
        public UsuariosController(UsuariosModel usuariosModel)
        {
            _usuariosModel = usuariosModel;
        }

        [HttpGet]
        [Route("ConsultarUsuarios")]
        public IActionResult ConsultarUsuarios()
        {
            try
            {
                var resultado = _usuariosModel.ConsultarUsuarios();

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
