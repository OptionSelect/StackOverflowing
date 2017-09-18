using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflowing.Data;
using StackOverflowing.Models;

namespace StackOverflowing.Controllers
{
    public class QtieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QtieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Qtie
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qties.ToListAsync());
        }

        // GET: Qtie/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtieModel = await _context.Qties
                .SingleOrDefaultAsync(m => m.ID == id);
            if (qtieModel == null)
            {
                return NotFound();
            }

            return View(qtieModel);
        }

        // GET: Qtie/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qtie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,QuestionID,TagID")] QtieModel qtieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qtieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qtieModel);
        }

        // GET: Qtie/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtieModel = await _context.Qties.SingleOrDefaultAsync(m => m.ID == id);
            if (qtieModel == null)
            {
                return NotFound();
            }
            return View(qtieModel);
        }

        // POST: Qtie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,QuestionID,TagID")] QtieModel qtieModel)
        {
            if (id != qtieModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qtieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QtieModelExists(qtieModel.ID))
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
            return View(qtieModel);
        }

        // GET: Qtie/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qtieModel = await _context.Qties
                .SingleOrDefaultAsync(m => m.ID == id);
            if (qtieModel == null)
            {
                return NotFound();
            }

            return View(qtieModel);
        }

        // POST: Qtie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qtieModel = await _context.Qties.SingleOrDefaultAsync(m => m.ID == id);
            _context.Qties.Remove(qtieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QtieModelExists(int id)
        {
            return _context.Qties.Any(e => e.ID == id);
        }
    }
}
