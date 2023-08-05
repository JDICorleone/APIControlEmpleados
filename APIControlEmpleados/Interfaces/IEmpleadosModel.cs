using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IEmpleadosModel
    {

        public List<ConsultarEmpleados> ConsultarEmpleados();

        public int AgregarEmpleado(Empleado entidad);


    }
}
