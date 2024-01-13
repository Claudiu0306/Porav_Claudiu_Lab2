using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Porav_Claudiu_Lab2.Data;
using Porav_Claudiu_Lab2.Models;

namespace Porav_Claudiu_Lab2.Pages.Jocuri
{
    public class CreateModel : PageModel
    {
        private readonly Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context _context;

        public CreateModel(Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jocuri Jocuri { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jocuri.Add(Jocuri);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
