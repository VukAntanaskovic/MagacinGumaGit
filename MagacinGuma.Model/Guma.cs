using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Model
{
    public class Guma
    {
        public int GumaId { get; set; }
        public string GumaProizvodjac { get; set; }
        public string GumaDimenzija { get; set; }
        public double GumaMaxBrzina { get; set; }
        public TipGume GumaTip { get; set; }
        public int GumaKolicina { get; set; }
        public DateTime GumaDatumKreiranja { get; set; }
        public Korisnik GumaKreiraoKorisnik { get; set; }
        public string GumaDatumIzmene { get; set; } 
        public Korisnik IzmenioKorisnik { get; set; }
    }
}
