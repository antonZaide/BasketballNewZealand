using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasketballNewZealand.Data;
using BasketballNewZealand.Models;

namespace BasketballNewZealand.Pages.Drafts
{
    public class DetailsModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public DetailsModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        public Draft Draft { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Draft = await _context.Drafts.FirstOrDefaultAsync(m => m.DraftID == id);

            if (Draft == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
