using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballNewZealand.Data;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Pages.Positions
{
    public class DetailsModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public DetailsModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FirstOrDefaultAsync(m => m.PositionID == id);

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
