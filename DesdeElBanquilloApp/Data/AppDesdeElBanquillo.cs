using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesdeElBanquilloApp.Models;

    public class AppDesdeElBanquillo : DbContext
    {
        public AppDesdeElBanquillo (DbContextOptions<AppDesdeElBanquillo> options)
            : base(options)
        {
        }

        public DbSet<DesdeElBanquilloApp.Models.Position> Position { get; set; } = default!;
    }
