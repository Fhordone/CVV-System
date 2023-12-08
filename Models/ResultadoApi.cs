namespace CCVLab.Models
{
    public class ResultadoApi
    {
        public string mensaje { get; set; }
        
        public List<Cita> lista { get; set; } 
        public Cita objeto { get; set; }
    }
}