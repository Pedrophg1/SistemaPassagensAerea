namespace Sistemapassagemaerea.Models
{
    public class Piloto
    {
        public string CpfTripulante { get; set; }
        public string LicencaDeVoo { get; set; }
        public string FuncaoNoVoo { get; set; }
        public Tripulante Tripulante { get; set; }
    }
}
