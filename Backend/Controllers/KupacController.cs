using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KupacController:ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public KupacController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Kupci.ToList());
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return new JsonResult(_context.Kupci.Find(sifra));
        }

        [HttpPost]
        public IActionResult Post(Kupac smjer)
        {
            _context.Kupci.Add(smjer);
            _context.SaveChanges();
            return new JsonResult(smjer);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Kupac smjer)
        {
            var smjerIzBaze = _context.Kupci.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            smjerIzBaze.Ime = smjer.Ime;
            smjerIzBaze.Prezime= smjer.Prezime;
            smjerIzBaze.Mjesto= smjer.Mjesto;
            smjerIzBaze.UlicaIBroj=smjer.UlicaIBroj;
            smjerIzBaze.BrojMobitela=smjer.BrojMobitela;

            _context.Kupci.Update(smjerIzBaze);
            _context.SaveChanges();

            return new JsonResult(smjerIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var smjerIzBaze = _context.Kupci.Find(sifra);
            _context.Kupci.Remove(smjerIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
