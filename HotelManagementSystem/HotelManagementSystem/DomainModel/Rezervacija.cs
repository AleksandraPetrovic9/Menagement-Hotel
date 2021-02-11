using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DomainModel
{
    public class Rezervacija
    {
        public Gost gost { get; set; }
        public Prostorija prostorija { get; set; }
        public String ukupnaCena { get; set; }
        public String aktivna { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public DateTime datumRezervacije{ get; set; }
    }
}
