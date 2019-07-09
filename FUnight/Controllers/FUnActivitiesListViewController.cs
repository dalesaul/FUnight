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
using Microsoft.AspNetCore.Authorization;

namespace FUnight.Controllers
{
    public class FUnActivitiesListViewController : Controller
    {
        private readonly ApplicationDbContext _context;

    
        private readonly UserManager<ApplicationUser> _userManager;

        public FUnActivitiesListViewController(ApplicationDbContext context,
                                        UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: FUnActivitiesListView
     
        public async Task<IActionResult> Index()
        {

            ApplicationUser user = await GetCurrentUserAsync();

            List<FUnActivity> activityList = await _context.Activities
                //.Where(activity => activity.ApplicationUserId == user.Id)
                .Include(f => f.ActivityType)
                .OrderBy(a => a.Rating)
                .ToListAsync();


            return View(activityList);
        }

        // GET: FUnActivitiesListView/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            if (id == null)
            {
                return NotFound();
            }

            var fUnActivity = await _context.Activities
                .Include(a => a.ActivityType)
                .Include(u => u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fUnActivity == null)
            {
                return NotFound();
            }

            return View(fUnActivity);
        }

        // GET: FUnActivitiesListView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FUnActivitiesListView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SuggestedDate,FoodAvailable,CostEstimate,Rating,ApplicationUserId,ActivityTypeId,UserGroupId")] FUnActivity fUnActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fUnActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fUnActivity);
        }

        // GET: FUnActivitiesListView/Edit/5
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

        // POST: FUnActivitiesListView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SuggestedDate,FoodAvailable,CostEstimate,Rating,ApplicationUserId,ActivityTypeId,UserGroupId")] FUnActivity fUnActivity)
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

        // GET: FUnActivitiesListView/Delete/5
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

        // POST: FUnActivitiesListView/Delete/5
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
