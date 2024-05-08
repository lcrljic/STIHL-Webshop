using Backend.Data;
using Backend.Mapping;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.SwaggerUi;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class RacunController : StihlWebshopController<Racun, RacunDTORead, RacunDTOInsertUpdate>
    {
        public RacunController(EdunovaContext context) : base(context)
        {
            Dbset = _context.Racuni;
            _mapper = new RacunMapping();


        }
        protected override void KontrolaBrisanje(Racun entitet)
        {
            var lista = _context.Kupci
                .Where(x => x.Sifra == entitet.Sifra)
                .ToList();
            if (lista != null && lista.Count > 0)
            {
                StringBuilder sb = new();
                sb.Append("Racun  se ne može obrisati jer je postavljen Korisnik: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Ime + " " + e.Prezime).Append(", ");
                }
                throw new Exception(sb.ToString()[..^2]); // umjesto sb.ToString().Substring(0, sb.ToString().Length - 2)
            }
        }

        protected override List<RacunDTORead> UcitajSve()
        {
            var lista = _context.Racuni
                    .Include(g => g.Kupac)

                    .ToList();
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }
        protected override Racun KreirajEntitet(RacunDTOInsertUpdate dto)
        {
            var Kupci = _context.Kupci.FirstOrDefault(k => k.Sifra == dto.KupacSifra);
            if (Kupci == null)
            {
                throw new Exception("Ne postoji kupac s imenom i prezimenom " + dto.KupacSifra + " u bazi");
            }

            var entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.Kupac = Kupci;
            entitet.Datum = dto.Datum;


            return entitet;
        }



        protected override Racun NadiEntitet(int Sifra)
        {

            return _context.Racuni
                           .Include(i => i.Kupac)
                           .FirstOrDefault(x => x.Sifra == Sifra)
                   ?? throw new Exception("Ne postoji unos sa šifrom " + Sifra + " u bazi");
        }

        protected override Racun PromjeniEntitet(RacunDTOInsertUpdate dto, Racun entitet)
        {
            var Kupac = _context.Kupci.Find(dto.KupacSifra) ?? throw new Exception("Ne postoji korisnik sa šifrom " + dto.KupacSifra + " u bazi");
            // ovdje je možda pametnije ići s ručnim mapiranje
            entitet.Kupac = Kupac;
            entitet.Datum = dto.Datum;

            return entitet;
        }
    }


}