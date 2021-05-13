using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballNewZealand.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public int DraftID { get; set; }
        public int PositionID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Draft Draft { get; set; }
        public Position Position { get; set; }

    }
}
