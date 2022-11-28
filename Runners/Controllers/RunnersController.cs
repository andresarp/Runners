using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Runners.Models;

namespace Runners.Controllers
{
    public class RunnersController : Controller
    {
        private readonly AthleticsContext _context;

        public RunnersController(AthleticsContext context)
        {
            _context = context;
        }

        // GET: Runners
        public async Task<IActionResult> Index()
        {
              return View(await _context.Runners.ToListAsync());
        }

        // GET: Runners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Runners == null)
            {
                return NotFound();
            }

            var runner = await _context.Runners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // GET: Runners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Runners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Minutes,Seconds")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runner);
        }

        // GET: Runners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Runners == null)
            {
                return NotFound();
            }

            var runner = await _context.Runners.FindAsync(id);
            if (runner == null)
            {
                return NotFound();
            }
            return View(runner);
        }

        // POST: Runners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,Minutes,Seconds")] Runner runner)
        {
            if (id != runner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunnerExists(runner.Id))
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
            return View(runner);
        }

        // GET: Runners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Runners == null)
            {
                return NotFound();
            }

            var runner = await _context.Runners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // POST: Runners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Runners == null)
            {
                return Problem("Entity set 'AthleticsContext.Runners'  is null.");
            }
            var runner = await _context.Runners.FindAsync(id);
            if (runner != null)
            {
                _context.Runners.Remove(runner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunnerExists(int id)
        {
          return _context.Runners.Any(e => e.Id == id);
        }
    }
}
