using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Logic;
using Database.Model.Shared;

namespace WebApiService.Controllers
{
    public class BusinessItemController : Controller
    {
        private readonly MainDatabaseContext _context;

        public BusinessItemController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: BusinessItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessItems.ToListAsync());
        }

        // GET: BusinessItem/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessItem = await _context.BusinessItems
                .FirstOrDefaultAsync(m => m.BusinessItemId == id);
            if (businessItem == null)
            {
                return NotFound();
            }

            return View(businessItem);
        }

        // GET: BusinessItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessItemId,Name")] BusinessItem businessItem)
        {
            if (ModelState.IsValid)
            {
                businessItem.BusinessItemId = Guid.NewGuid();
                _context.Add(businessItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessItem);
        }

        // GET: BusinessItem/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessItem = await _context.BusinessItems.FindAsync(id);
            if (businessItem == null)
            {
                return NotFound();
            }
            return View(businessItem);
        }

        // POST: BusinessItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BusinessItemId,Name")] BusinessItem businessItem)
        {
            if (id != businessItem.BusinessItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessItemExists(businessItem.BusinessItemId))
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
            return View(businessItem);
        }

        // GET: BusinessItem/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessItem = await _context.BusinessItems
                .FirstOrDefaultAsync(m => m.BusinessItemId == id);
            if (businessItem == null)
            {
                return NotFound();
            }

            return View(businessItem);
        }

        // POST: BusinessItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var businessItem = await _context.BusinessItems.FindAsync(id);
            _context.BusinessItems.Remove(businessItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessItemExists(Guid id)
        {
            return _context.BusinessItems.Any(e => e.BusinessItemId == id);
        }
    }
}
