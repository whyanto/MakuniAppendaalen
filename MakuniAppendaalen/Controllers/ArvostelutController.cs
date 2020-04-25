using System.Data.SqlClient;
using MakuniAppendaalen.Data;
using MakuniAppendaalen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakuniAppendaalen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArvostelutController : ControllerBase
    {
        MakuniDbContext _makuniDbContext;

        public ArvostelutController(MakuniDbContext makuniDbContext)
        {
            _makuniDbContext = makuniDbContext;
        }

        [HttpPost("[action]")]
        public IActionResult LahetaArvostelu(Arvostelu arvostelu)
        {
            string sql = "INSERT INTO dbo.KaikkiArvostelut(EAN, TykkasitkoMausta, TuotteenMakeus, ToimitJatkossa, PakkauksenAvaaminen, RakenneKuiva, RakenneJauhoinen, RakenneRapea, RakenneRoiskuva, RakenneIlmava, RakenneKova, RakennePehmea, RakenneHajoava, RakenneTasainen, MitenKierratetaan, Kommentti) " +
                            "VALUES (@EAN,@TykkasitkoMausta,@TuotteenMakeus,@ToimitJatkossa,@PakkauksenAvaaminen,@RakenneKuiva,@RakenneJauhoinen,@RakenneRapea,@RakenneRoiskuva,@RakenneIlmava,@RakenneKova,@RakennePehmea,@RakenneHajoava,@RakenneTasainen,@MitenKierratetaan,@Kommentti)";


            _makuniDbContext.Database.ExecuteSqlCommand(sql,
                new SqlParameter("@EAN", arvostelu.EAN),
                new SqlParameter("@TykkasitkoMausta", arvostelu.TykkasitkoMausta),
                new SqlParameter("@TuotteenMakeus", arvostelu.TuotteenMakeus),
                new SqlParameter("@ToimitJatkossa", arvostelu.ToimitJatkossa),
                new SqlParameter("@PakkauksenAvaaminen", arvostelu.PakkauksenAvaaminen),
                new SqlParameter("@RakenneKuiva", arvostelu.RakenneKuiva),
                new SqlParameter("@RakenneJauhoinen", arvostelu.RakenneJauhoinen),
                new SqlParameter("@RakenneRapea", arvostelu.RakenneRapea),
                new SqlParameter("@RakenneRoiskuva", arvostelu.RakenneRoiskuva),
                new SqlParameter("@RakenneIlmava", arvostelu.RakenneIlmava),
                new SqlParameter("@RakenneKova", arvostelu.RakenneKova),
                new SqlParameter("@RakennePehmea", arvostelu.RakennePehmea),
                new SqlParameter("@RakenneHajoava", arvostelu.RakenneHajoava),
                new SqlParameter("@RakenneTasainen", arvostelu.RakenneTasainen),
                new SqlParameter("@MitenKierratetaan", arvostelu.MikaKierratys),
                new SqlParameter("@Kommentti", arvostelu.Kommentti)

                );


            _makuniDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }





    }
}