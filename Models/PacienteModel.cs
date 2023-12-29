namespace CCVLab.Models
{
    public class ViewPacientModel
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Genero { get; set; }
    public string Nro_DNI { get; set; }
    public string Email { get; set; }
}
    public class Paciente
    {
        public int ID { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Fecha_Nacimiento { get; set; }
        public string? Genero { get; set; }
        public string? Direccion { get; set; }
        public string? Tipo_Documento { get; set; }
        public string? Nro_DNI { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}