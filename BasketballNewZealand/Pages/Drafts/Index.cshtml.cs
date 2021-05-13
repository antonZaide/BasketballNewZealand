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
    public class IndexModel : PageModel
    {
        private readonly BasketballNewZealand.Data.SportContext _context;

        public IndexModel(BasketballNewZealand.Data.SportContext context)
        {
            _context = context;
        }

        public IList<Draft> Draft { get;set; }

        public async Task OnGetAsync()
        {
            Draft = await _context.Drafts.ToListAsync();
        }
    }
}
