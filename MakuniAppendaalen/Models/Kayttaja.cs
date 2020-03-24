using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Models
{
    public class Kayttaja
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
