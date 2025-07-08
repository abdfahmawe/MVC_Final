using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var Categories = context.categories.ToList();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(category requist)
        {
           if(ModelState.IsValid)
            {
                context.categories.Add(requist);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requist);
        }
        
        public IActionResult Delete(int id)
        {
            var category = context.categories.Find(id);
            if(category is not null)
            {
                context.categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = context.categories.Find(id);
            if (category is not null)
            {
                return View(category);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Update(category requist)
        {
            if (ModelState.IsValid)
            {
                context.categories.Update(requist);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requist);
        }
    }
}
