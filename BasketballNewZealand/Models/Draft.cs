using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballNewZealand.Models
{
    public class Draft
    {
        public int DraftID { get; set; }
        public string TeamName { get; set; }
        public Player Player { get; set; }
    }
}
