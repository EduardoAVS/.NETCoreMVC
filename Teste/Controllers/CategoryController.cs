using Microsoft.AspNetCore.Mvc;
using Teste.Data;
using Teste.Models;

namespace Teste.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category"); // Já redireciona para o Controller atual automaticamente
                                                              // mas eu deixei explícito
            }
            return View();

        }
        public IActionResult Edit(int? Id) // Só funcionou quando o nome passado por parâmetro foi igual asp-route-nome
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(Id); // Só funciona na pk
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==categoryId); // Funciona em outros atributos
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == categoryId).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category"); // Já redireciona para o Controller atual automaticamente
                                                              // mas eu deixei explícito
            }
            return View();

        }
    }


}
