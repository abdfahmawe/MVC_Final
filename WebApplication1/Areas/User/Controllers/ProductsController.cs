using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Areas.User.Controllers
{
    [Area("User")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var products = context.products
                
                .ToList();

            return View(products); // لازم ملف Index.cshtml موجود
        }
        public IActionResult getproducts(int id)
        {
            var products = context.products
                .Where(p => p.CategoryId == id)
                .ToList();

            return View(products); // لازم ملف Index.cshtml موجود
        }
    }
}
