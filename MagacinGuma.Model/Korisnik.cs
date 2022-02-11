using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Model
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnikIme { get; set; }
        public string KorisnikPrezime { get; set; }
        public string KorisnikUsername { get; set; }
        public string KorisnikPassword { get; set; }
        public int KorisnikRola { get; set; }
        public bool KorisnikAktivan { get; set; }
    }
}
