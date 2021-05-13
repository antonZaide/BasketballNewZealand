using BasketballNewZealand.Data;
using BasketballNewZealand.Models;
using System;
using System.Linq;

namespace BasketballNewZealand.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Drafts.Any())
            {
                return;   // DB has been seeded
            }

            var drafts = new Draft[]
            {
                new Draft {TeamName = "Nelson Giants" },
                new Draft {TeamName = "Wellington Saints" },
                new Draft {TeamName = "Caterbury Rams" },
                new Draft {TeamName = "Southland Sharks" },
                new Draft {TeamName = "Otago Nuggets" }
            };

            context.Drafts.AddRange(drafts);
            context.SaveChanges();

            var positions = new Position[]
            {
                new Position{Placement = "Point Guard"},
                new Position{Placement = "Power Foward"},
                new Position{Placement = "Centre"},
                new Position{Placement = "Shooter"},
                new Position{Placement = "Shooting Guard"}
            };

            context.Positions.AddRange(positions);
            context.SaveChanges();

            var players = new Player[]
            {
                new Player{DraftID = 1, PositionID = 1, FirstName = "Andre", LastName = "Jordan"},
                new Player{DraftID = 2, PositionID = 2, FirstName = "Alex", LastName = "Cruz"},
                new Player{DraftID = 3, PositionID = 3, FirstName = "Sam", LastName = "Johnson"},
                new Player{DraftID = 4, PositionID = 4, FirstName = "Carl", LastName = "Jackson"},
                new Player{DraftID = 5, PositionID = 5, FirstName = "John", LastName = "Morgan"}
            };

            context.Players.AddRange(players);
            context.SaveChanges();
        }
    }
}