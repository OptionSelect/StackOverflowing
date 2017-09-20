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
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comment
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comment/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comments
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        //Second Blowup
        // GET: Comment/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["questionId"] = id;
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] int questionId, [FromForm] string body)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newComment = new CommentModel {QuestionModelID = questionId, Body = body, ApplicationUserId = user.Id};

                _context.Add(newComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Comment/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comments.SingleOrDefaultAsync(m => m.ID == id);
            if (commentModel == null)
            {
                return NotFound();
            }
            return View(commentModel);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Body,PostDate")] CommentModel commentModel)
        {
            if (id != commentModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentModelExists(commentModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(commentModel);
        }

        // GET: Comment/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comments
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentModel = await _context.Comments.SingleOrDefaultAsync(m => m.ID == id);
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool CommentModelExists(int id)
        {
            return _context.Comments.Any(e => e.ID == id);
        }
    }
}
