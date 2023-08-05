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

        public DbSet<Usuario> Usuario { get; set; }


        public DbSet<Empleado> Empleado { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToSqlQuery("EXEC ConsultarEmpleados");
        }

    }
}
