using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakuniAppendaalen.Data;
using MakuniAppendaalen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakuniAppendaalen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArvostelutController : ControllerBase
    {
        private MakuniDbContext _makuniDbContext;

        public ArvostelutController(MakuniDbContext makuniDbContext)
        {
            _makuniDbContext = makuniDbContext;
        }

        [HttpPost]
        public IActionResult LahetaArvostelu(Arvostelu arvostelu)
        {
            _makuniDbContext.KaikkiArvostelut.Add(arvostelu);
            _makuniDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}