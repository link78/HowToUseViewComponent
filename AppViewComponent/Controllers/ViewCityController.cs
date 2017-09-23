using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppViewComponent.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppViewComponent.Controllers
{
    
    public class ViewCityController : Controller
    {
        private ICity repo;

        public ViewCityController(ICity _repo)
        {
            repo = _repo;
        }
        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(City c)
        {
            repo.AddNew(c);

            return RedirectToAction("Create");
        }

        
        

    }
}
