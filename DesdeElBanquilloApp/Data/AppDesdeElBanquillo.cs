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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       // Configura la relación para partidos locales
modelBuilder.Entity<Match>()
.HasOne(m => m.HomeTeam)
.WithMany(t => t.HomeMatches)
.HasForeignKey(m => m.HomeTeamId)
.OnDelete(DeleteBehavior.Restrict);

        // Configura la relación para partidos visitantes
        modelBuilder.Entity<Match>()
        .HasOne(m => m.AwayTeam)
        .WithMany(t => t.AwayMatches)
        .HasForeignKey(m => m.AwayTeamId)
        .OnDelete(DeleteBehavior.Restrict);

        // Otras configuraciones...

        // Configura MatchPlayer con clave primaria Id
        modelBuilder.Entity<MatchPlayer>()
        .HasKey(mp => mp.Id);

        // Define un índice único para MatchId y PlayerId
        modelBuilder.Entity<MatchPlayer>()
        .HasIndex(mp => new { mp.MatchId, mp.PlayerId })
        .IsUnique();

        modelBuilder.Entity<MatchPlayer>()
        .HasOne(mp => mp.Match)
        .WithMany(m => m.MatchPlayers)
        .HasForeignKey(mp => mp.MatchId)
        .OnDelete(DeleteBehavior.Restrict); // Solo una cascada

        modelBuilder.Entity<MatchPlayer>()
        .HasOne(mp => mp.Player)
        .WithMany(p => p.MatchPlayers)
        .HasForeignKey(mp => mp.PlayerId)
        .OnDelete(DeleteBehavior.Restrict); // O NoAction

        modelBuilder.Entity<MatchPlayer>()
        .HasOne(mp => mp.Position)
        .WithMany(pos => pos.MatchPlayers)
        .HasForeignKey(mp => mp.PositionId)
        .OnDelete(DeleteBehavior.Restrict); // O NoAction
    }

public DbSet<DesdeElBanquilloApp.Models.Competition> Competition { get; set; } = default!;

public DbSet<DesdeElBanquilloApp.Models.Country> Country { get; set; } = default!;

public DbSet<DesdeElBanquilloApp.Models.Federation> Federation { get; set; } = default!;

public DbSet<DesdeElBanquilloApp.Models.FTeam> FTeam { get; set; } = default!;

public DbSet<DesdeElBanquilloApp.Models.Match> Match { get; set; } = default!;

public DbSet<DesdeElBanquilloApp.Models.Player> Player { get; set; } = default!;
}
