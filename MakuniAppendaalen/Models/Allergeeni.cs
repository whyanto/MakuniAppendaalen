using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Models
{
    public class Allergeeni
    {
        public string Name { get; set; }
        public string Arvo { get; set; }

        public Allergeeni(string name, string arvo)
        {
            Name = name;
            Arvo = arvo;
        }
    }
}
