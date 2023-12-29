namespace CCVLab.Models
{
    public class ViewCita
    {
        public int ID { get; set; }
        public string DNI_Paciente { get; set; }
        public string Fecha { get; set; }
        public string FK_Urgencia { get; set; }
        public string FK_Estado { get; set; }
    }
    public class Cita
    {
        public int ID { get; set; }
        public string? Tipo_Documento { get; set; }
        public string? DNI_Paciente { get; set; }
        public string? Nombres_Paciente { get; set; }
        public string? Apellidos_Paciente { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        public string FK_Urgencia { get; set; }
        public string FK_Sucursal { get; set; }
        public string FK_Estado { get; set; }
        public string FK_Estado_Pago { get; set; }
        public string FK_Usuario { get; set; }
        public string Observacion { get; set; }

    }
    public class CreateCitaModel
    {
        public int ID { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int FK_Urgencia { get; set; }
        public int FK_Sucursal { get; set; }
        public int FK_Estado { get; set; }
        public int FK_Estado_Pago { get; set; }
        public int FK_Usuario { get; set; }
        public int FK_Paciente { get; set; }
        public string Observacion { get; set; }
        public List<int> Examenes { get; set; }
    }
}