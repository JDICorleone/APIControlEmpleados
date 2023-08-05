using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuariosModel _usuariosModel;
        public UsuariosController(IUsuariosModel usuariosModel)
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

        [HttpPost]
        [Route("AgregarUsuario")]
        public IActionResult AgregarUsuario(Usuario entidad)
        {
            try
            {
                try
                {
                    return Ok(_usuariosModel.AgregarUsuario(entidad));
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
