using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesdeElBanquilloApp.Models;

namespace DesdeElBanquilloApp.Controllers
{
    public class PlayersController : Controller
    {
        private readonly AppDesdeElBanquillo _context;

        public PlayersController(AppDesdeElBanquillo context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var appDesdeElBanquillo = _context.Player.Include(p => p.Country).Include(p => p.Position).Include(p => p.Team);
            return View(await appDesdeElBanquillo.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.Country)
                .Include(p => p.Position)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.IdPlayer == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["idCountry"] = new SelectList(_context.Country, "idCountry", "Name");
            ViewData["idPosition"] = new SelectList(_context.Position, "IdPosition", "PositionName");
            ViewData["idTeam"] = new SelectList(_context.FTeam, "IdFTeam", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlayer,PlayerNumber,Name,isActive,Age,idCountry,idTeam,idPosition")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCountry"] = new SelectList(_context.Country, "idCountry", "Name", player.idCountry);
            ViewData["idPosition"] = new SelectList(_context.Position, "IdPosition", "PositionName", player.idPosition);
            ViewData["idTeam"] = new SelectList(_context.FTeam, "IdFTeam", "Name", player.idTeam);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["idCountry"] = new SelectList(_context.Country, "idCountry", "Name", player.idCountry);
            ViewData["idPosition"] = new SelectList(_context.Position, "IdPosition", "PositionName", player.idPosition);
            ViewData["idTeam"] = new SelectList(_context.FTeam, "IdFTeam", "Name", player.idTeam);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlayer,PlayerNumber,Name,isActive,Age,idCountry,idTeam,idPosition")] Player player)
        {
            if (id != player.IdPlayer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.IdPlayer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCountry"] = new SelectList(_context.Country, "idCountry", "Name", player.idCountry);
            ViewData["idPosition"] = new SelectList(_context.Position, "IdPosition", "PositionName", player.idPosition);
            ViewData["idTeam"] = new SelectList(_context.FTeam, "IdFTeam", "Name", player.idTeam);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.Country)
                .Include(p => p.Position)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.IdPlayer == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                _context.Player.Remove(player);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.IdPlayer == id);
        }
    }
}
