using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasketballNewZealand.Data;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public CreateModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DraftID"] = new SelectList(_context.Drafts, "DraftID", "DraftID");
        ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
