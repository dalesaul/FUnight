using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FUnight.Data;
using FUnight.Models;
using Microsoft.AspNetCore.Identity;

namespace FUnight.Controllers
{
    public class FUnActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public FUnActivitiesController(ApplicationDbContext context,
                                        UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: FUnActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activities.ToListAsync());
        }

        // GET: FUnActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUnActivity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fUnActivity == null)
            {
                return NotFound();
            }

            return View(fUnActivity);
        }

        // GET: FUnActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FUnActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SuggestedDate,FoodAvailable,CostEstimate,Rating,ApplicationUser_Id,ActivityType_Id,UserGroup_Id")] FUnActivity fUnActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fUnActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fUnActivity);
        }

        // GET: FUnActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUnActivity = await _context.Activities.FindAsync(id);
            if (fUnActivity == null)
            {
                return NotFound();
            }
            return View(fUnActivity);
        }

        // POST: FUnActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SuggestedDate,FoodAvailable,CostEstimate,Rating,ApplicationUser_Id,ActivityType_Id,UserGroup_Id")] FUnActivity fUnActivity)
        {
            if (id != fUnActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fUnActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FUnActivityExists(fUnActivity.Id))
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
            return View(fUnActivity);
        }

        // GET: FUnActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUnActivity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fUnActivity == null)
            {
                return NotFound();
            }

            return View(fUnActivity);
        }

        // POST: FUnActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fUnActivity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(fUnActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FUnActivityExists(int id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }
    }
}
