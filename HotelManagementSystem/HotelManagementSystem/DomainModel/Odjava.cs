using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace HotelManagementSystem.DomainModel
{
 public  class Odjava
    {
        public Gost gost { get; set; }
        public Prostorija prostorija { get; set; }

        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public DateTime datumOdjave { get; set; }
        public string licno { get; set; }
        public string osoblje { get; set; }
        public string uslovi { get; set; }
        public int ocena { get; set; }
    
}
}
