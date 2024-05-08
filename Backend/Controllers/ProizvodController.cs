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
    public class ProizvodController : StihlWebshopController<Proizvod, ProizvodDTORead, ProizvodDTOInsertUpdate>
    {
        public ProizvodController(EdunovaContext context) : base(context)
        {
            Dbset = _context.Proizvodi;
        }

        protected override void KontrolaBrisanje(Proizvod entitet)
        {
            var lista = _context.Stavke
                .Include(x => x.Proizvod)
                .Where(x => x.Proizvod != null && x.Proizvod.Sifra == entitet.Sifra)
                .ToList();
            if (lista != null && lista.Count > 0)
            {
                StringBuilder sb = new();
                sb.Append("Proizvod se ne može obrisati jer je postavljen na stavkama: ");
                foreach (var e in lista)
                {
                    sb.Append(e.Proizvod).Append(", ");
                }
                throw new Exception(sb.ToString()[..^2]);
            }
        }
    }
}