using APIControlEmpleados.Entities;

namespace APIControlEmpleados.Interfaces
{
    public interface IPuestosModel
    {
        public List<Puestos>? ConsultarPuestos();

        public int AgregarPuesto(Puestos puestos);
    }
}
