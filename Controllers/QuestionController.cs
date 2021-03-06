using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflowing.Data;
using StackOverflowing.Models;

namespace StackOverflowing.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Question
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        // GET: Question/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["questionId"] = id;

            if (id == null)
            {
                return NotFound();
            }

            var questionModel = await _context.Questions
                .Include(q => q.ApplicationUser)
                .Include(i => i.Answers)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionModel == null)
            {
                return NotFound();
            }

            return View(questionModel);
        }

        // GET: Question/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,VoteCount,Title,Body,UserID,PostDate")] QuestionModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                questionModel.ApplicationUserId = user.Id;
                _context.Add(questionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(questionModel);
        }

        // GET: Question/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionModel = await _context.Questions.SingleOrDefaultAsync(m => m.ID == id);
            if (questionModel == null)
            {
                return NotFound();
            }
            return View(questionModel);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VoteCount,Title,Body,UserID,PostDate")] QuestionModel questionModel)
        {
            if (id != questionModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionModelExists(questionModel.ID))
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
            return View(questionModel);
        }

        // GET: Question/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionModel = await _context.Questions
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionModel == null)
            {
                return NotFound();
            }

            return View(questionModel);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionModel = await _context.Questions.SingleOrDefaultAsync(m => m.ID == id);
            _context.Questions.Remove(questionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionModelExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }
    }
}
