namespace CCVLab.Models
{
    public class Cita
{
    public int ID { get; set; }
    public string NombresPaciente { get; set; }
    public string ApellidosPaciente { get; set; }
    public int DNI_Paciente { get; set; }
    public DateTime Fecha { get; set; }
    public string Hora { get; set; }
    public bool Urgencia { get; set; }
    public string FK_Estado { get; set; }
    public int FK_Usuario { get; set; }
    public int FK_Estado_Pago { get; set; }
    public int FK_Sucursal { get; set; }
    public int FK_Tipo_Doc { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
    public string Observacion { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }

}
}