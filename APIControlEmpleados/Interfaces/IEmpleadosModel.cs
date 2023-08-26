using APIControlEmpleados.Consults;
using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IEmpleadosModel
    {

        public List<ConsultarEmpleados> ConsultarEmpleados();

        public int AgregarEmpleado(Empleado entidad);

        public int EditarEmpleado(Empleado entidad);

        public List<Empleado> ConsultarEmpleados2();

        public int ActualizarVacaciones(Empleado entidad);

    }
}
