using System.ComponentModel.DataAnnotations;

namespace APIControlEmpleados.Entities
{
    public class Horarios
    {

        [Key]
        public int ID_HORARIO{ get; set; }

        public string HORARIO { get; set; } = string.Empty;


    }
}
