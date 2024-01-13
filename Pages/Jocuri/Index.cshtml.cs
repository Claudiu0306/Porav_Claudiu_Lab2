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
    public class IndexModel : PageModel
    {
        private readonly Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context _context;

        public IndexModel(Porav_Claudiu_Lab2.Data.Porav_Claudiu_Lab2Context context)
        {
            _context = context;
        }

        public IList<Pages_Jocuri_Edit> Jocuri { get;set; } = default!;

        public async Task OnGetAsync() => Jocuri = (IList<Pages_Jocuri_Edit>)await _context.Jocuri.ToListAsync();
    }
}
