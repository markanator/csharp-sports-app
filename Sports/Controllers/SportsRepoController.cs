using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsMVC.Data;
using SportsMVC.Models;

namespace SportsMVC.Controllers
{
    public class SportsRepoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportsRepoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SportsRepo
        public async Task<IActionResult> Index()
        {
            return View(await _context.US_Sports.ToListAsync());
        }

        // GET: SportsRepo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_SportsRepo = await _context.US_Sports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_SportsRepo == null)
            {
                return NotFound();
            }

            return View(m_SportsRepo);
        }

        // GET: SportsRepo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportsRepo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] m_SportsRepo m_SportsRepo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(m_SportsRepo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(m_SportsRepo);
        }

        // GET: SportsRepo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_SportsRepo = await _context.US_Sports.FindAsync(id);
            if (m_SportsRepo == null)
            {
                return NotFound();
            }
            return View(m_SportsRepo);
        }

        // POST: SportsRepo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] m_SportsRepo m_SportsRepo)
        {
            if (id != m_SportsRepo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m_SportsRepo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!m_SportsRepoExists(m_SportsRepo.Id))
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
            return View(m_SportsRepo);
        }

        // GET: SportsRepo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_SportsRepo = await _context.US_Sports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_SportsRepo == null)
            {
                return NotFound();
            }

            return View(m_SportsRepo);
        }

        // POST: SportsRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m_SportsRepo = await _context.US_Sports.FindAsync(id);
            _context.US_Sports.Remove(m_SportsRepo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool m_SportsRepoExists(int id)
        {
            return _context.US_Sports.Any(e => e.Id == id);
        }
    }
}
