using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    public class Kupac: Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Mjesto { get; set; }
        public string? UlicaIBroj { get; set; }
        public string? BrojMobitela { get; set; }

    }
}
