using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DomainModel
{
    public class Soba : Prostorija
    {
        public String brojKreveta { get; set; }
        public String klima { get; set; }
        public String tv { get; set; }
        public String terasa { get; set; }
        public String opis { get; set; }
        public String sprat { get; set; }
        
    }
}
