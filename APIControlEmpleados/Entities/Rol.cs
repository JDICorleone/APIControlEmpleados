using System.ComponentModel.DataAnnotations;

namespace APIControlEmpleados.Entities
{
    public class Rol
    {

            [Key]
            public int ID_ROL { get; set; }
            public string ROL { get; set; } = string.Empty;
        

    }
}
