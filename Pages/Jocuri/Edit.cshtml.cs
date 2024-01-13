using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Porav_Claudiu_Lab2.Data;
using Porav_Claudiu_Lab2.Models;

namespace Porav_Claudiu_Lab2.Pages.Jocuri
{
    public class EditModel : PageModel
    {
        private readonly Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context _context;

        public EditModel(Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Jocuri Jocuri { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jocuri =  await _context.Jocuri.FirstOrDefaultAsync(m => m.ID == id);
            if (jocuri == null)
            {
                return NotFound();
            }
            Jocuri = jocuri;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jocuri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JocuriExists(Jocuri.ID))
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

        private bool JocuriExists(int id)
        {
            return _context.Jocuri.Any(e => e.ID == id);
        }
    }
}
