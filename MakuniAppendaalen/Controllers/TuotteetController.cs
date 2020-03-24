using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Math;
using MakuniAppendaalen.Data;
using MakuniAppendaalen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakuniAppendaalen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuotteetController : ControllerBase
    {
        MakuniDbContext _makuniDbContext;

        public TuotteetController(MakuniDbContext makuniDbContext)
        {
            _makuniDbContext = makuniDbContext;
        }

        [HttpGet]
        public IActionResult Tuotteet()
        {
            var tuotteet = _makuniDbContext.Tuotteet;
            return Ok(tuotteet);
        }
        [HttpGet("[action]")]
        public IQueryable<object> Tuote(string ean)
        {
            var tuote = from v in _makuniDbContext.Tuotteet
                           where v.EAN == ean
                           select new
                           {
                               EAN = v.EAN,
                               Category = v.Category,
                               Name = v.Name,
                               Description = v.Description,
                               Image = v.Image,
                               UserId = v.UserId,
                               isORGANIC = v.isOrganic,
                               isLOWCALORY = v.isLowCalory
                           };
            return tuote;
        }

        [HttpGet("[action]")]
        public IQueryable<object> TuoteAlkaa(string nimi)
        {
            var tuote = from v in _makuniDbContext.Tuotteet
                        where v.Name.Contains(nimi)
                        select new
                        {
                            Ean = v.EAN,
                            Name = v.Name,
                            Image = v.Image
                        };
            return tuote;
        }
        [HttpGet("[action]")]
        public IQueryable<object> UusimmatTuotteet()
        {
            var tuote = 
                        from v in _makuniDbContext.Tuotteet
                        where v.UserId == 1
                        orderby v.EAN descending
                        select new
                        {
                            EAN = v.EAN,
                            Image = v.Image
                        };

            return tuote.Take(4);
        }

        [HttpGet("[action]")]
        public IQueryable<object> HaeRavintoarvot(string ean)
        {
            var tuote = from v in _makuniDbContext.Ravintoarvot
                        where v.EAN == ean
                        select new
                        {
                            EAN = v.EAN,
                            Energia = v.Energia,
                            Rasva = v.Rasva,
                            Tyydyttyneita = v.Tyydyttyneita,
                            Hiilihydraatit = v.Hiilihydraatit,
                            Sokereita = v.Sokereita,
                            Ravintokuitua = v.Ravintokuitua,
                            Proteini = v.Proteini,
                            Suola = v.Suola

                        };
            return tuote;
        }
        [HttpGet("[action]")]
        public IQueryable<object> HaeAllergeenit(string ean)
        {
            List<Allergeeni> allergeenitLista = new List<Allergeeni>();


            var tuote = from v in _makuniDbContext.Allergeenit
                        where v.EAN == ean
                        select new
                        {
                            
                            //v.EAN,
                            v.Maito_ja_maitotuotteet_myos_laktoosi,
                            v.Gluteenia_sisaltavat_viljat_ja_viljatuotteet,
                            v.Soijapavut_ja_soijapaputuotteet,
                            v.Vehna_ja_vehnatuotteet_eli_gluteenia_sisaltavat_viljat,
                            v.Munat_ja_munatuotteet,
                            v.Pahkinat_ja_pahkinatuotteet,
                            v.Mantelit_ja_mantelituotteet,
                            v.Cashewpahkinat_ja_cashew_pahkinatuotteet,
                            v.Hasselpahkinat_ja_hasselpahkinatuotteet,
                            v.Ayriaiset_ja_ayriaistuotteet,
                            v.Kalat_ja_kalatuotteet,
                            v.Maapahkinat_ja_maapahkinatuotteet,
                            v.Seesaminsiemenet_ja_seesaminsiementuotteet,
                            v.Rikkidioksidi_ja_sulfiitit,
                            v.Selleri_ja_sellerituotteet,
                            v.Sinappi_ja_sinappituotteet,
                            v.Lupiini_ja_lupiinituotteet,
                            v.Nilviaiset_ja_nilviaistuotteet,
                            v.Ohra_ja_ohratuotteet,
                            v.Kaura_jakauratuotteet
                        };

            foreach(var a in tuote)
            { 

                var props = a
                .GetType()
                .GetProperties()
                .Select(p => (p.Name, p.GetValue(a)))
                .ToList();

                        foreach (var t in props)
                        {
                            try
                            {
                                if (t.Item2 != null)
                                {
                                    string name = t.Name.Replace("_", " ");
                                    Allergeeni allerg = new Allergeeni(name, t.Item2.ToString());
                                    allergeenitLista.Add(allerg);
                                }

                            }
                            catch { continue; }
                        }
            }

            var allergeenit = allergeenitLista.AsQueryable();
            return allergeenit;

            
        }
    }
}