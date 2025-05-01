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
    public class FederationsController : Controller
    {
        private readonly AppDesdeElBanquillo _context;

        public FederationsController(AppDesdeElBanquillo context)
        {
            _context = context;
        }

        // GET: Federations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Federation.ToListAsync());
        }

        // GET: Federations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var federation = await _context.Federation
                .FirstOrDefaultAsync(m => m.idFederation == id);
            if (federation == null)
            {
                return NotFound();
            }

            return View(federation);
        }

        // GET: Federations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Federations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFederation,Name")] Federation federation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(federation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(federation);
        }

        // GET: Federations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var federation = await _context.Federation.FindAsync(id);
            if (federation == null)
            {
                return NotFound();
            }
            return View(federation);
        }

        // POST: Federations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFederation,Name")] Federation federation)
        {
            if (id != federation.idFederation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(federation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FederationExists(federation.idFederation))
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
            return View(federation);
        }

        // GET: Federations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var federation = await _context.Federation
                .FirstOrDefaultAsync(m => m.idFederation == id);
            if (federation == null)
            {
                return NotFound();
            }

            return View(federation);
        }

        // POST: Federations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var federation = await _context.Federation.FindAsync(id);
            if (federation != null)
            {
                _context.Federation.Remove(federation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FederationExists(int id)
        {
            return _context.Federation.Any(e => e.idFederation == id);
        }
    }
}
