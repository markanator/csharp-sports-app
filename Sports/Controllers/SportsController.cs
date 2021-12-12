using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsLib.Models;
using SportsMVC.Models;
using System.Linq;

namespace SportsMVC.Controllers
{
    public class SportsController : Controller
    {
        protected static USSportsRepo repo;
        public SportsController(USSportsRepo _repo)
        {
            repo =_repo;
        }

        public ActionResult Index()
        {
            var t = repo.SportsList;
            return View(repo.SportsList.ToArray());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            var fSport = repo.SportsList.Where(s => s.Name == id).FirstOrDefault();
            return View(fSport);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sport _sport)
        {
            try
            {
                repo.AddSport(_sport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Admin/Sports/Create");
            }
        }

        // GET: Admin/Edit/soccer
        public ActionResult Edit(string id)
        {
            var fSport = repo.SportsList.Where(s => s.Name == id).FirstOrDefault();
            return View(fSport);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Sport _sport)
        {
            try
            {
                var fSport = repo.SportsList.Where(s => s.Name == id).FirstOrDefault();
                fSport.Name = _sport.Name;
                fSport.Description = _sport.Description;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            var fSport = repo.SportsList.Where(s => s.Name == id).FirstOrDefault();

            return View(fSport);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Sport _sport)
        {
            try
            {
                var fSport = repo.SportsList.Where(s => s.Name == id).FirstOrDefault();
                repo.RemoveSport(fSport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
