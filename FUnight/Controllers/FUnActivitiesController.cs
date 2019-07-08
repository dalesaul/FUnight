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
using FUnight.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {

            ApplicationUser user = await GetCurrentUserAsync();

            List <FUnActivity> activityList = await _context.Activities
                .Where(activity => activity.ApplicationUserId == user.Id)
                .ToListAsync();


            return View(activityList);
        }

        // GET: FUnActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
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
        public async Task<IActionResult> Create()
        {
            List<ActivityType> ActivityTypes = await _context.ActivityTypes.ToListAsync();
            List<UserGroup> UserGroups = await _context.UserGroups.ToListAsync();

            var viewModel = new CreateFUnActivityViewModel()
            {
                ActivityTypeOptions = ActivityTypes.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Type
                }).ToList(),

                UserGroupOptions = UserGroups.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name
                }).ToList()

        };

        
            return View(viewModel);
        }

        // POST: FUnActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFUnActivityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vm.FUnActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<ActivityType> activityTypes = await _context.ActivityTypes.ToListAsync();

            vm.ActivityTypeOptions = activityTypes.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Type
            }).ToList();
                
            List<UserGroup> userGroups = await _context.UserGroups.ToListAsync();

            vm.UserGroupOptions = userGroups.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            }).ToList();

            return View(vm.FUnActivity);
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
        public async Task<IActionResult> Edit(int id, CreateFUnActivityViewModel vm)
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
