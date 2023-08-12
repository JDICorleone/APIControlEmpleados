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

        [HttpGet]
        [Route("ConsultarUsuarios2")]
        public IActionResult ConsultarUsuarios2()
        {
            try
            {
                var resultado = _usuariosModel.ConsultarUsuarios2();

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
                var resultado = _usuariosModel.AgregarUsuario(entidad);

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
        [Route("EditarUsuario")]
        public IActionResult EditarUsuario(Usuario entidad)
        {
            try
            {
                var resultado = _usuariosModel.EditarUsuario(entidad);

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



        [HttpPost]
        [Route("CorreoExiste")]
        public IActionResult CorreoExiste(Usuario entidad)
        {
            try
            {

                var resultado = _usuariosModel.CorreoExiste(entidad);


                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
