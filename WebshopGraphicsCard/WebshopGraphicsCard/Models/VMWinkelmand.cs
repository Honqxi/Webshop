using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopGraphicsCard.Models
{
    public class VMWinkelmand
    {
        public WinkelmandRepository WinkelmandRepo { get; set; }
        public Klant Klant { get; set; }
         // apparte class
        public double TotaalExclu { get; set; }
        public double BTW { get; set; }
        public double TotaalInclu { get; set; }

    }
}
