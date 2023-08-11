using Microsoft.AspNetCore.Mvc;
using APIControlEmpleados.Models;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Entities;

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

        [HttpGet]
        [Route("ConsultarEmpleados2")]
        public IActionResult ConsultarEmpleados2()
        {
            try
            {
                var resultado = _empleadosModel.ConsultarEmpleados2();

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
        [Route("AgregarEmpleado")]
        public IActionResult AgregarEmpleado(Empleado entidad)
        {
            try
            {
                var resultado = _empleadosModel.AgregarEmpleado(entidad);

                if (resultado != 0)
                {

                    return Ok(resultado);
                }
                else {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("EditarEmpleado")]
        public IActionResult EditarEmpleado(Empleado entidad)
        {
            try
            {
                var resultado = _empleadosModel.EditarEmpleado(entidad);

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

    }
}
