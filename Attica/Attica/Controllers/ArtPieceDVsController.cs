using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Attica.Data;
using Attica.Models;
using System.Globalization;

namespace Attica.Controllers
{
    public class ArtPieceDVsController : Controller
    {
        private readonly AtticaContext _context;

        public ArtPieceDVsController(AtticaContext context)
        {
            _context = context;
        }

        // GET: ArtPieceDVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArtPieceDV.Include(a => a.Artist).ToListAsync());
        }

        // GET: ArtPieceDVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artPieceDV = await _context.ArtPieceDV
                .FirstOrDefaultAsync(m => m.ArtPieceId == id);
            if (artPieceDV == null)
            {
                return NotFound();
            }

            return View(artPieceDV);
        }

        // GET: ArtPieceDVs/Create
        public IActionResult Create()
        {
            ViewBag.Artists = _context.Artist.OrderBy(a => a.Name).ToList();

            return View();
        }

        // POST: ArtPieceDVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtPieceDV artPieceDV, string price)
        {
            decimal priceValue;
            if (Decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out priceValue))
            {
                artPieceDV.Price = priceValue;
            }
            else
            {
                ModelState.AddModelError("Price", "Invalid price format");
            }

            if (ModelState.IsValid)
            {
                _context.Add(artPieceDV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artPieceDV);
        }


        // GET: ArtPieceDVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artPieceDV = await _context.ArtPieceDV.FindAsync(id);
            if (artPieceDV == null)
            {
                return NotFound();
            }

            ViewBag.Artists = await _context.Artist.OrderBy(a => a.Name).ToListAsync();

            return View(artPieceDV);
        }

        // POST: ArtPieceDVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtPieceDV artPieceDV, string price)
        {
            if (id != artPieceDV.ArtPieceId)
            {
                return NotFound();
            }

            decimal priceValue;
            if (Decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out priceValue))
            {
                artPieceDV.Price = priceValue;
            }
            else
            {
                ModelState.AddModelError("Price", "Invalid price format");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artPieceDV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtPieceDVExists(artPieceDV.ArtPieceId))
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

            ViewBag.Artists = await _context.Artist.OrderBy(a => a.Name).ToListAsync();
            return View(artPieceDV);
        }


        // GET: ArtPieceDVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artPieceDV = await _context.ArtPieceDV
                .FirstOrDefaultAsync(m => m.ArtPieceId == id);
            if (artPieceDV == null)
            {
                return NotFound();
            }

            return View(artPieceDV);
        }

        // POST: ArtPieceDVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artPieceDV = await _context.ArtPieceDV.FindAsync(id);
            if (artPieceDV != null)
            {
                _context.ArtPieceDV.Remove(artPieceDV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtPieceDVExists(int id)
        {
            return _context.ArtPieceDV.Any(e => e.ArtPieceId == id);
        }
    }
}
