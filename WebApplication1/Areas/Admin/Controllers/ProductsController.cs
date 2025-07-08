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
    }
}
