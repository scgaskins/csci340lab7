using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages.Cats
{
    public class CreateModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public CreateModel(csci340lab7.Data.csci340lab7Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cat Cat { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cat.Add(Cat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
