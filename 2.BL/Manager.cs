using _3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL
{
    public class Manager
    {
        TestTrainMenachemEntities ctx;
        public Manager()
        {
            ctx = new TestTrainMenachemEntities();
        }

        public List<City> Cities()
        {
            return ctx.Cities.OrderBy(c=>c.cityName.ToUpper()).ToList();
        }

        public List<Street> Streetes()
        {
            return ctx.Streets.OrderBy(s =>s.streetName).ToList(); 
        }

        public bool InsertCity(City newCity)
        {
            ctx.Cities.Add(new City { cityName = newCity.cityName });

            int save = ctx.SaveChanges();

            return save > 0;
        }

        public bool InsertStreet(Street newStreet)
        {

            ctx.Streets.Add(new Street { streetName = newStreet.streetName, cityId = newStreet.cityId });

            int save = ctx.SaveChanges();

            return save > 0;
        }
    }
}
