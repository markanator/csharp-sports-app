using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsLib.Interfaces;
using SportsLib.Models;
using SportsMVC.Models;
using System.Collections.Generic;
using System.Linq;


namespace SportsMVC.Controllers
{
    public class TeamsController : Controller
    {
        protected static USSportsRepo repo;
        protected static List<ITeam> teamLists;
        public TeamsController(USSportsRepo _repo)
        {
            repo = _repo;
            teamLists ??= new List<ITeam>();
            if (teamLists.Count == 0)
            {
                _repo.SportsList.ForEach(sport => sport.SportTeams.ForEach(team => teamLists.Add(team)));
            }
        }
        // GET: TeamsController
        public ActionResult Index()
        {
            return View(teamLists.ToArray());
        }

        // GET: TeamsController/Details/5
        public ActionResult Details(string id)
        {
            var fTeam = teamLists.Where(s => s.Name == id).FirstOrDefault();
            return View(fTeam);
        }

        // GET: TeamsController/Create
        public ActionResult Create()
        {
            return View(repo.SportsList.ToArray());
        }

        // POST: TeamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team _team)
        {
            try
            {
                var newTeam = new Team(_team.Sport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsController/Edit/5
        public ActionResult Edit(string id)
        {
            var fTeam = teamLists.Where(s => s.Name == id).FirstOrDefault();
            return View(fTeam);
        }

        // POST: TeamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Team _team)
        {
            try
            {
                var fTeam = teamLists.Where(s => s.Name == id).FirstOrDefault();
                fTeam.Name = _team.Name;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsController/Delete/5
        public ActionResult Delete(string id)
        {
            var fTeam = teamLists.Where(s => s.Name == id).FirstOrDefault();
            return View(fTeam);
        }

        // POST: TeamsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Team _team)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
