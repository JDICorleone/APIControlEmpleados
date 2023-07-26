using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IEmpleadosModel
    {

        public List<Empleado> ConsultarEmpleados();
    }
}
