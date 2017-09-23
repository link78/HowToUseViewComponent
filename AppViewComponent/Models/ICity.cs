using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppViewComponent.Models
{
    public interface ICity
    {
        IEnumerable<City> Cities { get; }
        void AddNew(City city);
    }

    public class CityRepo:ICity
    {
        private List<City> listCity = new List<City>
        {
            new City{Name="Paris", Country="France", Population=25450780},
            new City{ Name="Lyon", Country="France", Population=15698005},
            new City{Name="Chicago",Country="USA", Population=45120458},
            new City{Name="Denver",Country="USA", Population=12698154},
            new City{Name="Liverpool", Country="England", Population=14989785}
        };

        public IEnumerable<City> Cities => listCity;

        public void AddNew(City c)
        {
            listCity.Add(c);
        }
    }
}
