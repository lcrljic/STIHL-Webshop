using AutoMapper;
using Backend.Mappers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Backend.Mapping
{
    public class RacunMapping : Mapping<Racun, RacunDTORead, RacunDTOInsertUpdate>
    {

        public RacunMapping()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Racun, RacunDTORead>()
                .ConstructUsing(entitet =>
                 new RacunDTORead(
                    entitet.Sifra,
                    entitet.Datum,

                    entitet.Kupac == null ? "" : (entitet.Kupac.Ime
                        + " " + entitet.Kupac.Prezime).Trim()

                    ));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RacunDTOInsertUpdate, Racun>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Racun, RacunDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RacunDTOInsertUpdate(

                                         entitet.Datum,

                entitet.Kupac.Sifra



                    ));

            }));
        }




    }
}