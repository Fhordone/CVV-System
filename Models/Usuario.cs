using System.ComponentModel.DataAnnotations;

namespace CCVLab.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Nro_Colegiado { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? Horario_Consulta { get; set; }
        public int FK_Especialidad { get; set; }
        public string? Password { get; set; }
        public ICollection<UsuarioRol>? UsuarioRol { get; set; }
    }
}