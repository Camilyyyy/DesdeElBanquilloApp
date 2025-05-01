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
    public class FTeamsController : Controller
    {
        private readonly AppDesdeElBanquillo _context;

        public FTeamsController(AppDesdeElBanquillo context)
        {
            _context = context;
        }

        // GET: FTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.FTeam.ToListAsync());
        }

        // GET: FTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fTeam = await _context.FTeam
                .FirstOrDefaultAsync(m => m.IdFTeam == id);
            if (fTeam == null)
            {
                return NotFound();
            }

            return View(fTeam);
        }

        // GET: FTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFTeam,Name")] FTeam fTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fTeam);
        }

        // GET: FTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fTeam = await _context.FTeam.FindAsync(id);
            if (fTeam == null)
            {
                return NotFound();
            }
            return View(fTeam);
        }

        // POST: FTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFTeam,Name")] FTeam fTeam)
        {
            if (id != fTeam.IdFTeam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FTeamExists(fTeam.IdFTeam))
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
            return View(fTeam);
        }

        // GET: FTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fTeam = await _context.FTeam
                .FirstOrDefaultAsync(m => m.IdFTeam == id);
            if (fTeam == null)
            {
                return NotFound();
            }

            return View(fTeam);
        }

        // POST: FTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fTeam = await _context.FTeam.FindAsync(id);
            if (fTeam != null)
            {
                _context.FTeam.Remove(fTeam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FTeamExists(int id)
        {
            return _context.FTeam.Any(e => e.IdFTeam == id);
        }
    }
}
