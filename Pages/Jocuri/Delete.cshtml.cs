using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Porav_Claudiu_Lab2.Data;
using Porav_Claudiu_Lab2.Models;

namespace Porav_Claudiu_Lab2.Pages.Jocuri
{
    public class DeleteModel : PageModel
    {
        private readonly Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context _context;

        public DeleteModel(Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context context)
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

            var jocuri = await _context.Jocuri.FirstOrDefaultAsync(m => m.ID == id);

            if (jocuri == null)
            {
                return NotFound();
            }
            else
            {
                Jocuri = jocuri;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jocuri = await _context.Jocuri.FindAsync(id);
            if (jocuri != null)
            {
                Jocuri = jocuri;
                _context.Jocuri.Remove(Jocuri);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
