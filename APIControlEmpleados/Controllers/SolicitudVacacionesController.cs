using APIControlEmpleados.Entities;
using APIControlEmpleados.Interfaces;
using APIControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIControlEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudVacacionesController : Controller
    {
        private readonly ISolicitudVacacionesModel _solicitudVacacionesModel;
        public SolicitudVacacionesController(ISolicitudVacacionesModel solicitudVacacionesModel)
        {
            _solicitudVacacionesModel = solicitudVacacionesModel;
        }

        [HttpGet]
        [Route("ConsultarSolicitudes")]
        public IActionResult ConsultarSolicitudes()
        {
            try
            {
                var resultado = _solicitudVacacionesModel.ConsultarSolicitudes();

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
        [Route("AgregarSolicitud")]
        public IActionResult AgregarSolicitud(Solicitud_Vacaciones entidad)
        {
            try
            {
                var resultado = _solicitudVacacionesModel.AgregarSolicitud(entidad);

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
        

        [HttpGet]
        [Route("ConsultarSolicitudesEmpleado")]
        public IActionResult ConsultarSolicitudesEmpleado(int id)
        {
            try
            {
                var resultado = _solicitudVacacionesModel.ConsultarSolicitudesEmpleado(id);

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

        [HttpPut]
        [Route("CambiarEstado")]
        public IActionResult CambiarEstado(int id_solicitud, string estado)
        {
            try
            {
                var resultado = _solicitudVacacionesModel.CambiarEstado(id_solicitud, estado);

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
