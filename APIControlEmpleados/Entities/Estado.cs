using System.ComponentModel.DataAnnotations;

namespace APIControlEmpleados.Entities
{
    public class Estado
    {


        [Key]
        public int ID_ESTADO { get; set; }
        public string ESTADO { get; set; } = string.Empty;

    }
}
