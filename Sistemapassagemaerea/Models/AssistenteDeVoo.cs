namespace Sistemapassagemaerea.Models
{
    public class AssistenteDeVoo
    {
        public string CpfTripulante { get; set; }
        public string LicencaCms { get; set; }
        public Tripulante Tripulante { get; set; }
    }
}
