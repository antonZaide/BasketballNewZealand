﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballNewZealand.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Draft Draft { get; set; }
        public Position Position { get; set; }

    }
}