using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Models
{
    public class Tuote
    {
        [Key]
        public string EAN { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }

        public bool isOrganic { get; set; }
        public bool isLowCalory { get; set; }
    }
}
