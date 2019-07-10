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
using FUnight.Models.ViewModels;

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
                .OrderByDescending(a => a.Rating)
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

            var editActivity = await _context.Activities.FindAsync(id);

            if (editActivity == null)
            {
                return NotFound();
            }

            var activityTypes = await _context.ActivityTypes.ToListAsync();

            var userGroups = await _context.UserGroups.ToListAsync();

            var vm = new EditFUnActivityViewModel()
            {
                FUnActivity = editActivity,
                ActivityTypeOptions = activityTypes.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Type
                }).ToList(),
                UserGroupOptions = userGroups.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name
                }).ToList()
            };
            return View(vm);
        }

        // POST: FUnActivitiesListView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditFUnActivityViewModel vm)
        {
            if (id != vm.FUnActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.FUnActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FUnActivityExists(vm.FUnActivity.Id))
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
            return View(vm.FUnActivity);
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

        public async Task<IActionResult> UpvoteRatingOnFUnActivity([FromRoute] int id)
        {
            FUnActivity currentActivity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if (currentActivity.Rating == null)
            {
                currentActivity.Rating = 0; currentActivity.Rating++;
            }
            else
            {
                currentActivity.Rating++;
            }
            

            _context.Update(currentActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DownvoteRatingOnFUnActivity([FromRoute] int id)
        {
            FUnActivity currentActivity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if (currentActivity.Rating == null)
            {
                currentActivity.Rating = 0; currentActivity.Rating--;
            }

            else
            {
                currentActivity.Rating--;
            }

            _context.Update(currentActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
