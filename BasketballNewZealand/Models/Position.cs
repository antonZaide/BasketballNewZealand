using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballNewZealand.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        public string Placement { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
