using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Racun: Entitet
    {
        [ForeignKey("kupac")]
        public required Kupac Kupac { get; set; }
        public DateTime? Datum { get; set; }
    }
}
