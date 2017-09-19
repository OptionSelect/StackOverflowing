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
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        

        // GET: Answer
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Answers.ToListAsync());
        }

        // GET: Answer/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerModel = await _context.Answers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (answerModel == null)
            {
                return NotFound();
            }

            return View(answerModel);
        }

        // GET: Answer/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["questionId"] = id;
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] int questionId, [FromForm] string body)
        {

            Console.WriteLine($"creating answer afor {questionId}");
            
            if (ModelState.IsValid)
            {                
                var user = await _userManager.GetUserAsync(User);
                var newAnswer = new AnswerModel {QuestionModelID = questionId, Body = body, ApplicationUserId = user.Id};
               
                Console.WriteLine($"A - {newAnswer.QuestionModelID}, {newAnswer.Body}, {newAnswer.ApplicationUserId}");
                
                _context.Answers.Add(newAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Question", new {id=questionId});
            }
            return View();
        }

        // GET: Answer/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerModel = await _context.Answers.SingleOrDefaultAsync(m => m.ID == id);
            if (answerModel == null)
            {
                return NotFound();
            }
            return View(answerModel);
        }

        // POST: Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VoteCount,Body,UserID,PostDate,QuestionID")] AnswerModel answerModel)
        {
            if (id != answerModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerModelExists(answerModel.ID))
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
            return View(answerModel);
        }

        // GET: Answer/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerModel = await _context.Answers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (answerModel == null)
            {
                return NotFound();
            }

            return View(answerModel);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answerModel = await _context.Answers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Answers.Remove(answerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool AnswerModelExists(int id)
        {
            return _context.Answers.Any(e => e.ID == id);
        }
    }
}
