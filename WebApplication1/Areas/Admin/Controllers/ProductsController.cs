using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var products = context.products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = context.categories
     .Select(c => new SelectListItem
     {
         Value = c.Id.ToString(),
         Text = c.Name
     })
     .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(product requist)
        {
            if (ModelState.IsValid)
            {
                context.products.Add(requist);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requist);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.CategoryId = context.categories
            .Select(c => new SelectListItem
                {
             Value = c.Id.ToString(),
                Text = c.Name
                })
                .ToList();
            var products = context.products.Find(id);
            if (products is not null)
            {
                return View(products);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Update(product requist)
        {
            ViewBag.CategoryId = context.categories
          .Select(c => new SelectListItem
          {
              Value = c.Id.ToString(),
              Text = c.Name
          })
              .ToList();
            if (ModelState.IsValid)
            {
                context.products.Update(requist);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requist);
        }
        public IActionResult Delete(int id)
        {
            var product = context.products.Find(id);
            if (product is not null)
            {
                context.products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("index");

        }

    }
}
