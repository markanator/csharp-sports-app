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
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Teams.Include(m => m.Sport);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Team = await _context.Teams
                .Include(m => m.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Team == null)
            {
                return NotFound();
            }

            return View(m_Team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SportId")] m_Team m_Team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(m_Team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Team.SportId);
            return View(m_Team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Team = await _context.Teams.FindAsync(id);
            if (m_Team == null)
            {
                return NotFound();
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Team.SportId);
            return View(m_Team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SportId")] m_Team m_Team)
        {
            if (id != m_Team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m_Team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!m_TeamExists(m_Team.Id))
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
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Team.SportId);
            return View(m_Team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Team = await _context.Teams
                .Include(m => m.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Team == null)
            {
                return NotFound();
            }

            return View(m_Team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m_Team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(m_Team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool m_TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
