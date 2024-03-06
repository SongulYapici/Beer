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
    public class Class1Tests
    {
        [TestMethod()]
        public void ToStringTest()
        {
           
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beer = new()
            {
                Id = 1,
                Name = "Heineken",
                Abv = 25
            };
            beer.ValidateName();

            Beer beerNullName = new()
            {
                Id = 1, 
                Name = "",
                Abv = 25
            };
            Assert.ThrowsException<ArgumentException>(
                () => beerNullName.ValidateName());
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer BeerAbvLow = new()
            {
                Id = 1,
                Name = "Heineken",
                Abv = -10
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => BeerAbvLow.ValidateAbv());

            Beer beerInRange = new()
            {
                Id = 1,
                Name = "Heineken",
                Abv = 25
            };
            beerInRange.ValidateAbv();
        }
    }
    
}