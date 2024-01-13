using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Porav_Claudiu_Lab2.Models;

namespace Porav_Claudiu_Lab2.Data
{
    public class Porav_Claudiu_Lab2Context : DbContext
    {
        public Porav_Claudiu_Lab2Context (DbContextOptions<Porav_Claudiu_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Porav_Claudiu_Lab2.Models.Jocuri> Jocuri { get; set; } = default!;
    }
}
