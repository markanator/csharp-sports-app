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
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Player.Include(m => m.Sport).Include(m => m.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Player = await _context.Player
                .Include(m => m.Sport)
                .Include(m => m.Team)
                .Include(m => m.Team.TeamPlayers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Player == null)
            {
                return NotFound();
            }

            return View(m_Player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Roster,SportId,TeamId")] m_Player m_Player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(m_Player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Player.SportId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", m_Player.TeamId);
            return View(m_Player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Player = await _context.Player.FindAsync(id);
            if (m_Player == null)
            {
                return NotFound();
            }
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Player.SportId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", m_Player.TeamId);
            return View(m_Player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Roster,SportId,TeamId")] m_Player m_Player)
        {
            if (id != m_Player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m_Player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!m_PlayerExists(m_Player.Id))
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
            ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Name", m_Player.SportId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", m_Player.TeamId);
            return View(m_Player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m_Player = await _context.Player
                .Include(m => m.Sport)
                .Include(m => m.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (m_Player == null)
            {
                return NotFound();
            }

            return View(m_Player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m_Player = await _context.Player.FindAsync(id);
            _context.Player.Remove(m_Player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool m_PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
