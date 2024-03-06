using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetBeersTest()
        {
            var repo = new BeersRepository();
            var result = repo.GetBeers();
            Assert.AreEqual(5, result.Count); 
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var repo = new BeersRepository();
            var expectedBeerId = 1;

            var result = repo.GetById(expectedBeerId);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedBeerId, result.Id);
        }

        [TestMethod()]
        public void AddBeerTest()
        {
            var repo = new BeersRepository();
            var newBeer = new Beer { Name = "Test ny beer", Abv = 1.1 };

            var result = repo.AddBeer(newBeer);
            var allBeers = repo.GetBeers();

            Assert.IsNotNull(result);
            Assert.AreEqual(6, allBeers.Count);
            Assert.IsTrue(allBeers.Any(b => b.Name == "Test ny beer"));
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            var repo = new BeersRepository();
            var beerIdToDelete = 1;

            var result = repo.DeleteBeer(beerIdToDelete);
            var allBeers = repo.GetBeers();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, allBeers.Count); 
            Assert.IsFalse(allBeers.Any(b => b.Id == beerIdToDelete));
        }

        [TestMethod()]
        public void UpdateBeersTest()
        {
            var repo = new BeersRepository();
            var beerIdToUpdate = 1;
            var updatedData = new Beer { Name = "Opdatere Name", Abv = 3.2 };

            var result = repo.UpdateBeers(beerIdToUpdate, updatedData);
            var updatedBeer = repo.GetById(beerIdToUpdate);

            Assert.IsNotNull(result);
            Assert.AreEqual("Opdatere Name", updatedBeer.Name);
            Assert.AreEqual(6.5, updatedBeer.Abv);
        }
    }
}