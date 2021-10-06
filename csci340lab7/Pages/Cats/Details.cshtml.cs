using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages.Cats
{
    public class DetailsModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public DetailsModel(csci340lab7.Data.csci340lab7Context context)
        {
            _context = context;
        }

        public Cat Cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cat.FirstOrDefaultAsync(m => m.ID == id);

            if (Cat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
