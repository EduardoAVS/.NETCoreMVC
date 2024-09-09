using Microsoft.AspNetCore.Mvc;

namespace Teste.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
