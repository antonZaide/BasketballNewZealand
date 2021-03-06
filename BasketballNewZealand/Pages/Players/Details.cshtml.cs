using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballNewZealand.Data;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public DetailsModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players
                .Include(p => p.Draft)
                .Include(p => p.Position).FirstOrDefaultAsync(m => m.PlayerID == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
