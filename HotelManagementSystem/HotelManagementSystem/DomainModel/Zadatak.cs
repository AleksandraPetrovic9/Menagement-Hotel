using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DomainModel
{
    public class Zadatak
    {
        public Radnik radnik { get; set; }
        public Prostorija prostorija { get; set; }
        public String naziv { get; set; }
        public String hitno { get; set; }
        public DateTime datum { get; set; }
    }
}
