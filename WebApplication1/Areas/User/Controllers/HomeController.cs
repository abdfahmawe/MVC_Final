using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        ApplicationDbContext context =  new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View(categories);
        }
    }
}
