using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpellsDomain.Model;
using SpellsInfrasturcture;

namespace SpellsInfrasturcture.Controllers
{
    public class RangeTypesController : Controller
    {
        private readonly DndSpellsDbContext _context;

        public RangeTypesController(DndSpellsDbContext context)
        {
            _context = context;
        }

        // GET: RangeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RangeTypes.ToListAsync());
        }

        // GET: RangeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeType = await _context.RangeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rangeType == null)
            {
                return NotFound();
            }

            return View(rangeType);
        }

        // GET: RangeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RangeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,Label,Id")] RangeType rangeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rangeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rangeType);
        }

        // GET: RangeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeType = await _context.RangeTypes.FindAsync(id);
            if (rangeType == null)
            {
                return NotFound();
            }
            return View(rangeType);
        }

        // POST: RangeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Value,Label,Id")] RangeType rangeType)
        {
            if (id != rangeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rangeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RangeTypeExists(rangeType.Id))
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
            return View(rangeType);
        }

        // GET: RangeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeType = await _context.RangeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rangeType == null)
            {
                return NotFound();
            }

            return View(rangeType);
        }

        // POST: RangeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rangeType = await _context.RangeTypes.FindAsync(id);
            if (rangeType != null)
            {
                _context.RangeTypes.Remove(rangeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RangeTypeExists(int id)
        {
            return _context.RangeTypes.Any(e => e.Id == id);
        }
    }
}
