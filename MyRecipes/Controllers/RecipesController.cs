using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using System.Web;
using MyRecipes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;
using System.Net;

namespace MyRecipes.Controllers
{
    public class Recipes : Controller {

        private MyRecipesContext _dbContext;
        public Recipes(MyRecipesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("ID, Name,Description")] Recipe recipe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random rand = new Random();
                    recipe.ID = rand.Next();
                    _dbContext.Add(recipe);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(recipe);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(
        [Bind("ID, Name,Description")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var recipeToUpdate = _dbContext.Recipes.Where(x => x.ID == recipe.ID).SingleOrDefault();
                if (await TryUpdateModelAsync<Recipe>(recipeToUpdate,
                    "",
                    recipe => recipe.ID, recipe => recipe.Name, recipe => recipe.Description))
                {
                    try
                    {
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }
                }
            }

            return View(recipe);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Recipe recipe, int recipeID)
        {
            var selectedRecipe = _dbContext.Recipes.Where(x => x.ID == recipe.ID).SingleOrDefault();
            return View(selectedRecipe);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_dbContext.Recipes.ToList());
        }

        public ActionResult Details(int ID)
        {
            Recipe recipe = _dbContext.Recipes.Find(ID);
            return View(recipe);
        }

        public ActionResult Delete(Recipe recipe, int recipeID)
        {
            var selectedRecipe = _dbContext.Recipes.Where(x => x.ID == recipe.ID).SingleOrDefault();
            return View(selectedRecipe);
        }

        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            Recipe recipe = _dbContext.Recipes.Find(id);
            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

