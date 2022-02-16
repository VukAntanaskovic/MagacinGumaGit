using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Model
{
    public class Kupac
    {
        public int KupacId { get; set; }
        public string KupacIme { get; set; }
        public string KupacPrezime { get; set; }
        public string KupacAdresa { get; set; }
        public string IspisKupca 
        { 
            get
            {
                return KupacIme + " " + KupacPrezime + " " + KupacAdresa;
            } 
        }
    }
}
