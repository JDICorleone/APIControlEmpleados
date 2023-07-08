using APIControlEmpleados.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIControlEmpleados.Models
{
    public class ControlEmpleadosContext : DbContext
    {
        public ControlEmpleadosContext(DbContextOptions<ControlEmpleadosContext> opciones)
        : base(opciones)
        {
        }

        public DbSet<Usuarios> Usuario { get; set; }
    }
}
