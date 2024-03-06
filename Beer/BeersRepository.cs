using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer
{
    public class BeersRepository : IBeersRepository
    {
        private int _nextId = 6;
        private readonly List<Beer> _beers;

        public BeersRepository()
        {
            _beers = new List<Beer>
            {
            new Beer { Id = 1, Name = "Heineken", Abv = 3.2},
            new Beer { Id = 2, Name = "Beck´s", Abv = 5.2},
            new Beer { Id = 3, Name = "Stella Artois", Abv = 11.5},
            new Beer { Id = 4, Name = "Guinness", Abv = 2.2},
            new Beer { Id = 5, Name = "Blue Moon Belgian White", Abv = 4.6}
            };
        }
        public List<Beer> GetBeers(string? nameStart = null, string? sortby = null)
        {
            List<Beer> result = new List<Beer>(_beers);

            if (nameStart != null)
            {
                result = result.FindAll(b => b.Name.StartsWith(nameStart));
            }
            if (sortby != null)
            {
                switch (sortby)
                {
                    case "Name":
                        result.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "Abv":
                        result.Sort((b1, b2) => b1.Abv.CompareTo(b2.Abv));
                        break;
                }
            }
            return result;
        }
        public Beer? GetById(int id)
        {
            return _beers.Find(beer => beer.Id == id);
        }
        public Beer AddBeer(Beer beer)
        {
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }
        public Beer? GetBeer(int id)
        {
            return _beers.Find(b => b.Id == id);
        }

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = _beers.Find(b => b.Id == id);
            if (beer != null)
            {
                _beers.Remove(beer);
            }
            return beer;
        }
        public Beer? UpdateBeers(int Id, Beer data)
        {
            Beer? beerToUpdate = _beers.Find(b => b.Id == Id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = data.Name;
                beerToUpdate.Abv = data.Abv;
            }
            return beerToUpdate;
        }

    }
}

