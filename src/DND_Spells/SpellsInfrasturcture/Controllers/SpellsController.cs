using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            ViewData["AreaId"] = new SelectList(_context.Areas.Select(a => new
            {
                a.Id,
                Area = _context.AreaTypes.Where(t => t.Id == a.AreaTypeId).First().Label + ", " + a.AreaSize + " feet"
            }).ToList(), "Id", "Area");

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short");

            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes.Select(c => new
            {
                c.Id,
                CastingTime = c.Value + " " + c.Label
            }).ToList(), "Id", "CastingTime");

            ViewData["DurationId"] = new SelectList(_context.Durations.Select(d => new
            {
                d.Id,
                Duration = (from type in _context.DurationTypes
                            where type.Id == d.DurationTypeId
                            select (type.Value + " " + type.Label)).First()

            }).ToList(), "Id", "Duration");

            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes.Select(r => new
            {
                r.Id,
                Range = r.Value + " " + r.Label
            }).ToList(), "Id", "Range");

            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "Id", "Label");

            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpellId,BookId,SchoolId,Level,Name,Description,Ritual,CastingTimeTypeId,DurationId,RangeTypeId,AreaId,Verbal,Somatic,Material,Id")] Spell spell)
        {
            spell.Duration = _context.Durations.First(d => d.Id == spell.DurationId);
            spell.Duration.DurationType = _context.DurationTypes.First(e => e.Id == spell.Duration.DurationTypeId);
            spell.School = _context.SchoolOfMagics.First(s => s.Id == spell.SchoolId);
            spell.Area = _context.Areas.First(e => e.Id == spell.AreaId);
            spell.Area.AreaType = _context.AreaTypes.First(e => e.Id == spell.Area.AreaTypeId);
            spell.Book = _context.Books.First(e => e.Id == spell.BookId);
            spell.CastingTimeType = _context.CastingTimeTypes.First(e => e.Id == spell.CastingTimeTypeId);
            spell.RangeType = _context.RangeTypes.First(e => e.Id == spell.RangeTypeId);

            ModelState.Clear();
            TryValidateModel(spell);

            if (ModelState.IsValid)
            {
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AreaId"] = new SelectList(_context.Areas.Select(a => new
            {
                a.Id,
                Area = _context.AreaTypes.Where(t => t.Id == a.AreaTypeId).First().Label + ", " + a.AreaSize + " feet"
            }).ToList(), "Id", "Area");

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short");

            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes.Select(c => new
            {
                c.Id,
                CastingTime = c.Value + " " + c.Label
            }).ToList(), "Id", "CastingTime");

            ViewData["DurationId"] = new SelectList(_context.Durations.Select(d => new
            {
                d.Id,
                Duration = (from type in _context.DurationTypes
                            where type.Id == d.DurationTypeId
                            select (type.Value + " " + type.Label)).First()

            }).ToList(), "Id", "Duration");

            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes.Select(r => new
            {
                r.Id,
                Range = r.Value + " " + r.Label
            }).ToList(), "Id", "Range");

            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "Id", "Label");

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

            ViewData["AreaId"] = new SelectList(_context.Areas.Select(a => new
            {
                a.Id,
                Area = _context.AreaTypes.Where(t => t.Id == a.AreaTypeId).First().Label + ", " + a.AreaSize + " feet"
            }).ToList(), "Id", "Area");

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short");

            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes.Select(c => new
            {
                c.Id,
                CastingTime = c.Value + " " + c.Label
            }).ToList(), "Id", "CastingTime");

            ViewData["DurationId"] = new SelectList(_context.Durations.Select(d => new
            {
                d.Id,
                Duration = (from type in _context.DurationTypes
                            where type.Id == d.DurationTypeId
                            select (type.Value + " " + type.Label)).First()

            }).ToList(), "Id", "Duration");

            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes.Select(r => new
            {
                r.Id,
                Range = r.Value + " " + r.Label
            }).ToList(), "Id", "Range");

            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "Id", "Label");

            //ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "Id", "Label");
            //ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Id", spell.AreaId);
            //ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short", spell.BookId);
            //ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes, "Id", "Label", spell.CastingTimeTypeId);
            //ViewData["DurationId"] = new SelectList(_context.Durations, "Id", "Id", spell.DurationId);
            //ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes, "Id", "Label", spell.RangeTypeId);
            //ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "SchoolId", "Label", spell.SchoolId);
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

            spell.Duration = _context.Durations.First(d => d.Id == spell.DurationId);
            spell.Duration.DurationType = _context.DurationTypes.First(e => e.Id == spell.Duration.DurationTypeId);
            spell.School = _context.SchoolOfMagics.First(s => s.Id == spell.SchoolId);
            spell.Area = _context.Areas.First(e => e.Id == spell.AreaId);
            spell.Area.AreaType = _context.AreaTypes.First(e => e.Id == spell.Area.AreaTypeId);
            spell.Book = _context.Books.First(e => e.Id == spell.BookId);
            spell.CastingTimeType = _context.CastingTimeTypes.First(e => e.Id == spell.CastingTimeTypeId);
            spell.RangeType = _context.RangeTypes.First(e => e.Id == spell.RangeTypeId);

            ModelState.Clear();
            TryValidateModel(spell);

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

            ViewData["AreaId"] = new SelectList(_context.Areas.Select(a => new
            {
                a.Id,
                Area = _context.AreaTypes.Where(t => t.Id == a.AreaTypeId).First().Label + ", " + a.AreaSize + " feet"
            }).ToList(), "Id", "Area");

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Short");

            ViewData["CastingTimeTypeId"] = new SelectList(_context.CastingTimeTypes.Select(c => new
            {
                c.Id,
                CastingTime = c.Value + " " + c.Label
            }).ToList(), "Id", "CastingTime");

            ViewData["DurationId"] = new SelectList(_context.Durations.Select(d => new
            {
                d.Id,
                Duration = (from type in _context.DurationTypes
                            where type.Id == d.DurationTypeId
                            select (type.Value + " " + type.Label)).First()

            }).ToList(), "Id", "Duration");

            ViewData["RangeTypeId"] = new SelectList(_context.RangeTypes.Select(r => new
            {
                r.Id,
                Range = r.Value + " " + r.Label
            }).ToList(), "Id", "Range");

            ViewData["SchoolId"] = new SelectList(_context.SchoolOfMagics, "Id", "Label");

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
