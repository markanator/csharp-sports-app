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
    public class SportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sport
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sports.Include(m => m.Repo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Sport = await _context.Sports
                .Include(m => m.Repo)
                .Include(m => m.SportTeams)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Sport == null)
            {
                return NotFound();
            }

            return View(m_Sport);
        }

        // GET: Sport/Create
        public IActionResult Create()
        {
            ViewData["RepoId"] = new SelectList(_context.US_Sports, "Id", "RepoName");
            return View();
        }

        // POST: Sport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,RepoId")] m_Sport m_Sport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(m_Sport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepoId"] = new SelectList(_context.US_Sports, "Id", "RepoName", m_Sport.RepoId);
            return View(m_Sport);
        }

        // GET: Sport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Sport = await _context.Sports.FindAsync(id);
            if (m_Sport == null)
            {
                return NotFound();
            }
            ViewData["RepoId"] = new SelectList(_context.US_Sports, "Id", "RepoName", m_Sport.RepoId);
            return View(m_Sport);
        }

        // POST: Sport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,RepoId")] m_Sport m_Sport)
        {
            if (id != m_Sport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m_Sport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!m_SportExists(m_Sport.Id))
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
            ViewData["RepoId"] = new SelectList(_context.US_Sports, "Id", "RepoName", m_Sport.RepoId);
            return View(m_Sport);
        }

        // GET: Sport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Sport = await _context.Sports
                .Include(m => m.Repo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Sport == null)
            {
                return NotFound();
            }

            return View(m_Sport);
        }

        // POST: Sport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m_Sport = await _context.Sports.FindAsync(id);
            _context.Sports.Remove(m_Sport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool m_SportExists(int id)
        {
            return _context.Sports.Any(e => e.Id == id);
        }
    }
}
