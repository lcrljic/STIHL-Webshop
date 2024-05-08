
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public record KupacDTORead(int Sifra, string? Ime, string? Prezime, string? Mjesto,
        string? UlicaIBroj, string? BrojMobitela);

    public record KupacDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string? Ime,
        [Required(ErrorMessage = "Prezime obavezno")]
        string? Prezime,
        [Required(ErrorMessage = "Mjesto obavezno")]
        string? Mjesto,
        [Required(ErrorMessage = "Ulica i broj obavezni")]
        string? UlicaIBroj,
        [Required(ErrorMessage = "Broj mobitela obavezan")]
        string? BrojMobitela);



    public record ProizvodDTORead(int Sifra, string? Naziv, DateTime? Datumnabave, decimal? Cijena, bool? Aktivan);

    public record ProizvodDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
        string? Naziv,
        Decimal? Cijena,
        DateTime? Datumnabave,
        bool? Aktivan);


    public record RacunDTORead(int Sifra, DateTime? Datum, string? KupacImePrezime);

    public record RacunDTOInsertUpdate(
        [Required(ErrorMessage = "Datum obavezno")]
    DateTime? Datum,
    int? KupacSifra);

}