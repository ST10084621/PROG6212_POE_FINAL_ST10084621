using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_FINAL_PROG6212.Data;
using POE_FINAL_PROG6212.Models;
using ClassLibraryStudy;
using Microsoft.AspNetCore.Authorization;

namespace POE_FINAL_PROG6212.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        // variable to store userId
        private static string userId;


        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        // user must be logged in to make use of the website
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // get the specific userId of the logged in user
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // return only the modules of the logged in user
            return View(await _context.Module.Where(a => a.studentID == userId).ToListAsync());
        }
        

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .FirstOrDefaultAsync(m => m.ModuleId == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }



        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleId,hoursWorked,code,name,noOfCredits,classHoursPerWeek,remaininghours,selfStudyHours,semNoOfWeeks,studentID")] Module @module)
        {
            if (ModelState.IsValid)
            {
                // userId is equal to that of who is logged in
                module.studentID = userId;
                // using DLL for calculating self study hours
                module.selfStudyHours = ClassLibraryStudy.Class1.calc(module.noOfCredits, module.semNoOfWeeks, module.classHoursPerWeek);
                // remaininghours is obtained by multiplying the selfstudyhours by the number of weeks
                module.remaininghours = Convert.ToInt32(module.selfStudyHours) * module.semNoOfWeeks;
                // the hoursWorked for each module is initialized to 0
                module.hoursWorked = 0;
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Module.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int hoursWorked, [Bind("ModuleId,hoursWorked,code,name,noOfCredits,classHoursPerWeek,remaininghours,selfStudyHours,semNoOfWeeks,studentID")] Module @module)
        {
            if (id != @module.ModuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // user enters hours they have worked on a module, and it then gets subtracted from the remainingHours
                    module.remaininghours = module.remaininghours - hoursWorked;
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.ModuleId))
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
            return View(@module);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .FirstOrDefaultAsync(m => m.ModuleId == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @module = await _context.Module.FindAsync(id);
            _context.Module.Remove(@module);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleExists(int id)
        {
            return _context.Module.Any(e => e.ModuleId == id);
        }
    }
}
