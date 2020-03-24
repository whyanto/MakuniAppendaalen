using MakuniAppendaalen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Data
{
    public class MakuniDbContext : DbContext
    {
        public MakuniDbContext(DbContextOptions<MakuniDbContext> options) : base(options)
        {

        }
        public DbSet<Tuote> Tuotteet { get; set; }
        public DbSet<Kayttaja> Kayttajat { get; set; }

        public DbSet<Allergeenit> Allergeenit { get; set; }
        public DbSet<Ravintoarvo> Ravintoarvot { get; set; }
    }
}
