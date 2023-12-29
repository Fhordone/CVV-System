namespace CCVLab.Models
{
    public class ResultadoApi
    {
        public string mensaje { get; set; }
        
        public List<ViewCita> lista { get; set; } 
        public Cita objeto { get; set; }
        public CreateCitaModel obj { get; set; }
    }
    public class ResultadoApiPaciente
    {
        public string mensaje { get; set; }
        
        public List<Paciente> lista { get; set; } 
        public Paciente objeto { get; set; }
    }
    public class ResultadoApiExamen
    {
        public string mensaje { get; set; }
        
        public List<Examen> lista { get; set; } 
        public Examen objeto { get; set; }
    }
}