using System.ComponentModel.DataAnnotations;

namespace APIControlEmpleados.Entities
{
    public class Usuarios
    {
        [Key]
        public int ID_USUARIO { get; set; }

        public string? CORREO { get; set; }

        public string? CONTRASEÑA { get; set; }

        public int ID_ROL{ get; set; }


    }
}
