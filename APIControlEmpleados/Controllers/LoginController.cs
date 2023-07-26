using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly IUsuariosModel _usuariosModel;
        public LoginController(IUsuariosModel usuariosModel)
        {
            _usuariosModel = usuariosModel;
        }


        [HttpPost]
        [Route("ValidarUsuario")]
        public IActionResult ValidarUsuario(Usuario entidad)
        {
            try
            {

                var resultado = _usuariosModel.ValidarUsuario(entidad);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
