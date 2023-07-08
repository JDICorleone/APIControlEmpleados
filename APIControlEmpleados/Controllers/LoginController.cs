using APIControlEmpleados.Entities;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly UsuariosModel _usuariosModel;
        public LoginController(UsuariosModel usuariosModel)
        {
            _usuariosModel = usuariosModel;
        }


        [HttpPost]
        [Route("ValidarUsuario")]
        public IActionResult ValidarUsuario(Usuarios entidad)
        {
            try
            {


                var resultado = _usuariosModel.ValidarUsuario(entidad);

                if (resultado != null)
                {
                    return Ok();
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
