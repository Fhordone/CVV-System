namespace CCVLab.Models
{
    public class Cita
    {
        public int ID { get; set; }
        public string NombresPaciente { get; set; }
        public string ApellidosPaciente { get; set; }
        public string DNI_Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string FK_Urgencia { get; set; }
        public string FK_Sucursal { get; set; }
        public string FK_Estado { get; set; }
        public string FK_Estado_Pago { get; set; }
        public string FK_Usuario { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Observacion { get; set; }
        public string FK_Tipo_Doc { get; set; }

    }
    public class CreateCitaModel
    {
        public int ID { get; set; }
        public string NombresPaciente { get; set; }
        public string ApellidosPaciente { get; set; }
        public string DNI_Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int FK_Urgencia { get; set; }
        public int FK_Sucursal { get; set; }
        public int FK_Estado { get; set; }
        public int FK_Estado_Pago { get; set; }
        public int FK_Usuario { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Observacion { get; set; }
        public int FK_Tipo_Doc { get; set; }

    }
    public class UpdatedCitaModel
    {
        public int ID { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int FK_Urgencia { get; set; }
        public int FK_Estado { get; set; }
        public int FK_Estado_Pago { get; set; }
        public string Observacion { get; set; }
    }
}