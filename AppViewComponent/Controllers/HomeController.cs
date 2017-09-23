using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppViewComponent.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private IProduct repo;

        public HomeController(IProduct _repo)
        {
            repo = _repo;
        }
        
        public IActionResult Index()
        {
            return View(repo.Products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product p)
        {
            
                repo.AddNew(p);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
