using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Backend.Models
{
    public class Stavka : Entitet
    {

        [ForeignKey("racun")]
        public Racun? Racun { get; set; }

        [ForeignKey("proizvod")]

        public Proizvod? Proizvod { get; set; }
        public int? Kolicina { get; set; }
        public Decimal? Cijena { get; set; }
    }
}