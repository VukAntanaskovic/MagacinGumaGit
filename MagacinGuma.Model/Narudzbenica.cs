using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Model
{
    public class Narudzbenica
    {
        public int NarudzbenicaId { get; set; }
        public Korisnik KreiraoKorisnik { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool NarudzbenicaOtvorena { get; set; }
    }
}
