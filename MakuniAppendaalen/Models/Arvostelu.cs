using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Models
{
    public class Arvostelu
    {
        [Key]
        public string EAN { get; set; }
        [Required]
        public int TykkasitkoMausta { get; set; }
        [Required]
        public int TuotteenMakeus { get; set; }
        [Required]
        public int ToimitJatkossa { get; set; }
        [Required]
        public int PakkauksenAvaaminen { get; set; }
        [Required]
        public int RakenneKuiva { get; set; }
        [Required]
        public int RakenneJauhoinen { get; set; }
        [Required]
        public int RakenneRapea { get; set; }
        [Required]
        public int RakenneRoiskuva { get; set; }
        [Required]
        public int RakenneIlmava { get; set; }
        [Required]
        public int RakenneKova { get; set; }
        [Required]
        public int RakennePehmea { get; set; }
        [Required]
        public int RakenneHajoava { get; set; }
        [Required]
        public int RakenneTasainen { get; set; }
        [Required]
        public string MikaKierratys { get; set; }     //Lasi,Metalli,Muovi,Pahvi,Paperi,Seka
        [Required]
        public string Kommentti { get; set; }

    }
}
