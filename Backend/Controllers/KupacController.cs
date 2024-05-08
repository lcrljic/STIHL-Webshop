using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KupacController : StihlWebshopController<Kupac, KupacDTORead, KupacDTOInsertUpdate>
    {
        public KupacController(EdunovaContext context) : base(context)
        {
            Dbset = _context.Kupci;
        }
        protected override void KontrolaBrisanje(Kupac entitet)
        {
            var lista = _context.Racuni
                .Include(x => x.Kupac)
                .Where(x => x.Kupac.Sifra == entitet.Sifra)
                .ToList();
            if (lista != null && lista.Count > 0)
            {


                throw new Exception("Kupac se ne moze obrist jer ima racune"); // umjesto sb.ToString().Substring(0, sb.ToString().Length - 2)
            }
        }

    }
}