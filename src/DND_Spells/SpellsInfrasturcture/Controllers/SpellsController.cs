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
    public class SpellsController : Controller
    {
        private readonly DndSpellsDbContext _context;

        public SpellsController(DndSpellsDbContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            var dndSpellsDbContext = _context.Spells.Include(s => s.Area).Include(s => s.Book).Include(s => s.CastingTimeType).Include(s => s.Duration).Include(s => s.RangeType).Include(s => s.School);
            return View(await dndSpellsDbContext.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .Include(s => s.Area)
                .Include(s => s.Book)
                .Include(s => s.CastingTimeType)
                .Include(s => s.Duration)
                .Include(s => s.RangeType)
                .Include(s => s.School)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short");
            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes, "Id", "Label");
            ViewData["DurationId"] = new SelectList(_context.Durations, "Id", "Id");
            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes, "Id", "Label");
            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "SchoolId", "Label");
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpellId,BookId,SchoolId,Level,Name,Description,Ritual,CastingTimeTypeId,DurationId,RangeTypeId,AreaId,Verbal,Somatic,Material,Id")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Id", spell.AreaId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short", spell.BookId);
            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes, "Id", "Label", spell.CastingTimeTypeId);
            ViewData["DurationId"] = new SelectList(_context.Durations, "Id", "Id", spell.DurationId);
            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes, "Id", "Label", spell.RangeTypeId);
            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "SchoolId", "Label", spell.SchoolId);
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Id", spell.AreaId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short", spell.BookId);
            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes, "Id", "Label", spell.CastingTimeTypeId);
            ViewData["DurationId"] = new SelectList(_context.Durations, "Id", "Id", spell.DurationId);
            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes, "Id", "Label", spell.RangeTypeId);
            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "SchoolId", "Label", spell.SchoolId);
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpellId,BookId,SchoolId,Level,Name,Description,Ritual,CastingTimeTypeId,DurationId,RangeTypeId,AreaId,Verbal,Somatic,Material,Id")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Id", spell.AreaId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short", spell.BookId);
            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes, "Id", "Label", spell.CastingTimeTypeId);
            ViewData["DurationId"] = new SelectList(_context.Durations, "Id", "Id", spell.DurationId);
            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes, "Id", "Label", spell.RangeTypeId);
            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "SchoolId", "Label", spell.SchoolId);
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .Include(s => s.Area)
                .Include(s => s.Book)
                .Include(s => s.CastingTimeType)
                .Include(s => s.Duration)
                .Include(s => s.RangeType)
                .Include(s => s.School)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spell = await _context.Spells.FindAsync(id);
            if (spell != null)
            {
                _context.Spells.Remove(spell);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return _context.Spells.Any(e => e.Id == id);
        }
    }
}
