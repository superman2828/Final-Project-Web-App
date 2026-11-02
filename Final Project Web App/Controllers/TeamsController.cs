using Final_Project_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Web_App.Controllers
{
    public class TeamsController : Controller
    {
        private readonly TeamContext _context;

        public TeamsController(TeamContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? conferenceId, int? divisionId)
        {
            var teams = _context.Teams
                .Include(t => t.Division)
                .Include(t => t.Conference)
                .AsQueryable();

            if (conferenceId != null)
                teams = teams.Where(t => t.conferenceId == conferenceId);
            if (divisionId != null)
                teams = teams.Where(t => t.divisionId == divisionId);

            ViewBag.Conferences = await _context.Conferences.ToListAsync();
            ViewBag.Divisions = await _context.Divisions.ToListAsync();
            ViewBag.SelectedConference = conferenceId;
            ViewBag.SelectedDivision = divisionId;

            return View(await teams.OrderBy(t => t.TeamName).ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Division)
                .Include(t => t.Conference)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (team == null) return NotFound();
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View(new Teams());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teams team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LoadDropdowns();
            return View(team);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();
            LoadDropdowns();
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teams team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LoadDropdowns();
            return View(team);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Division)
                .Include(t => t.Conference)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Teams team)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void LoadDropdowns()
        {
            ViewBag.Conferences = new SelectList(_context.Conferences, "conferenceId", "ConferenceName");
            ViewBag.Divisions = new SelectList(_context.Divisions, "divisionId", "divisionName");
        }
    }
}