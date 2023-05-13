using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cyber_Safe_Academy.Data;
using Cyber_Safe_Academy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cyber_Safe_Academy.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Quiz
        public async Task<IActionResult> Index()
        {
            // Retrieves all quizzes from the database and passes them to the view.
            return View(await _context.Quiz.ToListAsync());
        }
        [Route("Quiz/TakeQuiz/{id}")]                           // This attribute specifies the route template for the method. It indicates that the method should be accessed through the URL path "Quiz/TakeQuiz/{id}", where "{id}" is a placeholder for a specific quiz ID. This allows the method to handle HTTP requests targeting this specific route.
        [HttpPost]                                              // This attribute indicates that the method should be invoked when an HTTP POST request is made to the specified route. It restricts the method to handle only POST requests and not other HTTP methods like GET or PUT.
        public async Task<IActionResult> SubmitAnswers(QuizAnswersViewModel model)
        {
            // Retrieves the selected quiz from the database based on the provided ID.
            var quiz = await _context.Quiz.Include(tm => tm.Questions)
               .FirstOrDefaultAsync(m => m.ID == model.QuizID);
            // Checks the user's answers against the correct answers and sets the corresponding boolean flags.
            if (model.Answer_0 == quiz.Questions.ToList()[0].CorrectAnswer)
            {
                model.Answer_0correct = true;
            }
            if (model.Answer_1 == quiz.Questions.ToList()[1].CorrectAnswer)
            {
                model.Answer_1correct = true;
            }
            if (model.Answer_2 == quiz.Questions.ToList()[2].CorrectAnswer)
            {
                model.Answer_2correct = true;
            }
            // Marks that answers have been submitted and passes the model and quiz information to the view.
            model.AnswersSubmitted = true;

            model.Quiz = quiz;

            return View("TakeQuiz",model);
        }
        // GET: Quiz/TakeQuiz/5
        public async Task<IActionResult> TakeQuiz(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Retrieves the specified quiz from the database based on the provided ID.
            var quiz = await _context.Quiz.Include(tm => tm.Questions)
                .FirstOrDefaultAsync(m => m.ID == id);
            // If the quiz is not found, returns a "Not Found" error.
            if (quiz == null)
            {
                return NotFound();
            }
            // Creates a new QuizAnswersViewModel and passes the quiz information to the view.
            return View(new QuizAnswersViewModel()
            {
                Quiz=quiz
            }
           );
        }

        // GET: Quiz/Create
        [Authorize(Roles = "Admin,Teacher")]                            // This attribute specifies that access to the controller or the controller action method is restricted to users who are authenticated and belong to either the "Admin" or "Teacher" roles. It ensures that only users with the specified roles can access the associated functionality.
        public IActionResult Create()
        {
            // Displays the create quiz view.
            return View();
        }

        // POST: Quiz/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Create([Bind("ID,Name,TrainingModuleID")] Quiz quiz)
        {
            // Validates the quiz model and saves it to the database if valid.
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Edit/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Retrieves the quiz with the specified ID from the database.
            var quiz = await _context.Quiz.FindAsync(id);

            // If the quiz is not found, returns a "Not Found" error.
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,TrainingModuleID")] Quiz quiz)
        {
            if (id != quiz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Updates the quiz in the database with the modified values.
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.ID))
                    {
                        // If the quiz doesn't exist, returns a "Not Found" error.
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Retrieves the quiz with the specified ID from the database.
            var quiz = await _context.Quiz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quiz == null)
            {
                // If the quiz is not found, returns a "Not Found" error.
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Retrieves the quiz with the specified ID from the database.
            var quiz = await _context.Quiz.FindAsync(id);
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            // Checks if a quiz with the specified ID exists in the database.
            return _context.Quiz.Any(e => e.ID == id);
        }
    }
}
