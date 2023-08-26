using APIControlEmpleados.Consults;
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

        public DbSet<Planilla> Planilla { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<Horarios> Horarios { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Periodo_Pago> Periodo_Pago { get; set; }

        public DbSet<Puestos> Puestos { get; set; }

        public DbSet<Solicitud_Vacaciones> Solicitud_Vacaciones { get; set; }


        //Metodos ------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
