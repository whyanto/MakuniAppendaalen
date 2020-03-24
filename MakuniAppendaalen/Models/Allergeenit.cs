using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakuniAppendaalen.Models
{
    public class Allergeenit
    {
        [Key]
        public string EAN { get; set; }
        public string Maito_ja_maitotuotteet_myos_laktoosi { get; set; }
        public string Gluteenia_sisaltavat_viljat_ja_viljatuotteet { get; set; }
        public string Soijapavut_ja_soijapaputuotteet { get; set; }
        public string Vehna_ja_vehnatuotteet_eli_gluteenia_sisaltavat_viljat { get; set; }
        public string Munat_ja_munatuotteet { get; set; }
        public string Pahkinat_ja_pahkinatuotteet { get; set; }
        public string Mantelit_ja_mantelituotteet { get; set; }
        public string Cashewpahkinat_ja_cashew_pahkinatuotteet { get; set; }
        public string Hasselpahkinat_ja_hasselpahkinatuotteet { get; set; }
        public string Ayriaiset_ja_ayriaistuotteet { get; set; }
        public string Kalat_ja_kalatuotteet { get; set; }
        public string Maapahkinat_ja_maapahkinatuotteet { get; set; }
        public string Seesaminsiemenet_ja_seesaminsiementuotteet { get; set; }
        public string Rikkidioksidi_ja_sulfiitit { get; set; }
        public string Selleri_ja_sellerituotteet { get; set; }
        public string Sinappi_ja_sinappituotteet { get; set; }
        public string Lupiini_ja_lupiinituotteet { get; set; }
        public string Nilviaiset_ja_nilviaistuotteet { get; set; }
        public string Ohra_ja_ohratuotteet { get; set; }
        public string Kaura_jakauratuotteet { get; set; }

    }
}
