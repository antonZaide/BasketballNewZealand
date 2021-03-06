using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasketballNewZealand.Data;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public EditModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DraftID"] = new SelectList(_context.Drafts, "DraftID", "DraftID");
           ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }
    }
}
