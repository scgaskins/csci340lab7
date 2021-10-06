using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csci340lab7.Pages.Cats
{
    public class IndexModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public IndexModel(csci340lab7.Data.csci340lab7Context context)
        {
            _context = context;
        }

        public IList<Cat> Cat { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Breeds { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CatBreed { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> breedQuery = from c in _context.Cat
                                            orderby c.Breed
                                            select c.Breed;

            var cats = from c in _context.Cat
                         select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cats = cats.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CatBreed))
            {
                cats = cats.Where(x => x.Breed == CatBreed);
            }

            Breeds = new SelectList(await breedQuery.Distinct().ToListAsync());
            Cat = await cats.ToListAsync();
        }
    }
}
