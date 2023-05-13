using Cyber_Safe_Academy.Data;
using Cyber_Safe_Academy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Cyber_Safe_Academy.Controllers
{
    public class TrainingController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public TrainingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;



        }


        [Authorize(Roles = "Admin,Teacher")]

        [Route("Training/Edit/{ID}")]
        public IActionResult Edit(int ID)

        {
            // Disable lazy loading to ensure all related entities are eagerly loaded
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;

            // Retrieve the training module with the specified ID, including its related materials
            var trainingmodule = _dbContext.TrainingModules.Include(tm => tm.Materials).Where(tm => tm.Id == ID).First();

            return View(trainingmodule);

        }
        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        [Route("Training/Edit/{ID}")]
        public async Task<ActionResult> Edit(int id, IFormCollection form)
        {
            // Retrieve the training module with the specified ID, including its related materials
            var trainingmodule = _dbContext.TrainingModules.Include(tm => tm.Materials).Where(tm => tm.Id == id).First();
            if (await TryUpdateModelAsync(trainingmodule))         // TODO - Perform necessary operations to update the model data in your database or storage
            {
                foreach (var material in trainingmodule.Materials)
                {
                    //TODO - update the materials and save
                }
                _dbContext.Entry(trainingmodule).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(trainingmodule);             // If there are validation errors, return the same view with the model data to display the errors
        }
        public IActionResult List()
        {
            // Retrieve all training modules from the database
            var trainingModules = _dbContext.TrainingModules.ToList();

            return View(trainingModules);
        }
        [Route("Training/View/{ID}")]
        public IActionResult View(int ID)
        {
            // Disable lazy loading to ensure all related entities are eagerly loaded
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;

            // Retrieve the training module with the specified ID, including its related materials
            var trainingmodule = _dbContext.TrainingModules.Include(tm => tm.Materials).Where(tm => tm.Id == ID).First();
            return View(trainingmodule);
        }

    }
}
