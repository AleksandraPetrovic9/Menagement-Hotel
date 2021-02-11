using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DomainModel
{
    public class Prijava
    {
        public Gost gost { get; set; }
        public Prostorija prostorija { get; set; }
       
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public DateTime datumPrijave { get; set; }
        
        
    }

    }
