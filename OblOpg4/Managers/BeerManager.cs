using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OblOpg1;

namespace OblOpg4.Managers
{
    public class BeerManager
    {
        private static int _nextId = 1;

        private static readonly List<Beer> Data = new List<Beer>
        {
            new Beer(_nextId++, "Læks øl", 25.0, 4.7),
            new Beer(_nextId++, "fLæks øl", 14.0, 8.3),
            new Beer(_nextId++, "uLæks øl", 5.0, 67.5)
        };

        public IEnumerable<Beer> GetAll(string name = null, string sortBy = null)
        {
            List<Beer> beer = new List<Beer>(Data);

            if (name != null)
            {
                beer = beer.FindAll(beer => beer.Name != null && beer.Name.StartsWith(name));
            }

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        beer = beer.OrderBy(beer => beer.Name).ToList();
                        break;
                    case "price":
                        beer = beer.OrderBy(beer => beer.Price).ToList();
                        break;
                    case "Abv":
                        beer = beer.OrderBy(beer => beer.Abv).ToList();
                        break;
                }
            }

            return beer;
        }

        public Beer GetById(int id)
        {
            return Data.Find(beer => beer.Id == id);
        }

        public Beer Add(Beer newBeer)
        {
            newBeer.Id = _nextId++;
            Data.Add(newBeer);
            return newBeer;
        }

        public Beer Delete(int id)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            Data.Remove(beer);
            return beer;
        }

        public Beer Update(int id, Beer updatedBeer)
        {
            Beer beer = Data.Find(beer1 => beer1.Id == id);
            if (beer == null) return null;
            beer.Name = updatedBeer.Name;
            beer.Price = updatedBeer.Price;
            beer.Abv = updatedBeer.Abv;
            return beer;
        }
    }
}
    