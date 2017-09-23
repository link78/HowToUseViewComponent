using AppViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppViewComponent.ViewComponents
{

    //importing the ViewCompent interface for the viewComponent to work
    public class CitySummary:ViewComponent
    {

        private ICity repo;
        public CitySummary(ICity _repo)
        {
            repo = _repo;
        }

        public IViewComponentResult Invoke(bool list)
        {
            var model = new ViewCityModel
            {
                Cities = repo.Cities.Count(),
                Population = repo.Cities.Sum(c => c.Population)
            };

            //string target = RouteData.Values["id"] as string;
            //var model = repo.Cities.Where(city => target == null || string.Compare(city.Country, target, true) == 0);

            if (list)
            {
                return View("CityList", repo.Cities);
            }
            else
            {
                return View(model);
            }

           // return View(new ViewCityModel { Cities = model.Count(), Population = model.Sum(p=>p.Population) });

        }
    }


    public class DensePopulation:ViewComponent
    {
        private ICity repo;

        public DensePopulation(ICity _repo)
        {
            repo = _repo;
        }

        public string Invoke()
        {
            var p = repo.Cities.Select(c => c.Population).Max();

            var b = repo.Cities.OrderByDescending(v => v.Population).First().Name;

            return $"Most polulated country is {b} with :  {p} millions people";
        }
    }
}
