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

        [HttpGet]
        [Route("BuscarCorreo")]
        public IActionResult BuscarCorreo(string CorreoUsuario)
        {
            try
            {
                var resultado = _usuariosModel.BuscarCorreo(CorreoUsuario);

                if (resultado == null)
                    return NotFound();
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RecuperarContrasenna")]
        public IActionResult RecuperarContrasenna(Usuario entidad)
        {
            try
            {
               int resultado = _usuariosModel.RecuperarContrasenna(entidad);

                if (resultado != null) {

                    return Ok(resultado);

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
