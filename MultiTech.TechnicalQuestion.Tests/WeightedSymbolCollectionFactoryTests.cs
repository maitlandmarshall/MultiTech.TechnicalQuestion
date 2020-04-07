using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiTech.TechnicalQuestion.Domain;
using MultiTech.TechnicalQuestion.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiTech.TechnicalQuestion.Tests
{
    [TestClass]
    public class WeightedSymbolCollectionFactoryTests
    {
        [TestMethod]
        public void Create_NoInput_Returns7Symbols()
        {
            // Create an ASP.Net Core Web API that simulates a spinning wheel that can land on 7 possible outcomes:

            WeightedSymbolCollectionFactory factory = new WeightedSymbolCollectionFactory();

            var symbols = factory.Create();

            Assert.IsTrue(symbols.Count() == 7);
        }

        [TestMethod]
        public void Create_NoInput_ContainsAppleMangoCherryMelonPeachOrangeLemon()
        {
            // Create an ASP.Net Core Web API that simulates a spinning wheel that can land on 7 possible outcomes:
            // ["Apple", "Mango", "Cherry", "Melon", "Peach", "Orange", "Lemon"]

            WeightedSymbolCollectionFactory factory = new WeightedSymbolCollectionFactory();

            var symbols = factory.Create();

            Assert.IsTrue(symbols.Any(y => y.Name == "Apple"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Mango"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Cherry"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Melon"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Peach"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Orange"));
            Assert.IsTrue(symbols.Any(y => y.Name == "Lemon"));
        }

        [TestMethod]
        public void Create_NoInput_WeightsAreEqualToSpecification()
        {
            // Each outcome has a weighted probablity as described.
            // Apple - 10%, Mango - 15%, Cherry - 20%, Melon - 15%, Peach - 10%, Orange - 20%, Lemon - 10%

            WeightedSymbolCollectionFactory factory = new WeightedSymbolCollectionFactory();

            var symbols = factory.Create();

            WeightedSymbol apple = symbols.Single(y => y.Name == "Apple");
            WeightedSymbol mango = symbols.Single(y => y.Name == "Mango");
            WeightedSymbol cherry = symbols.Single(y => y.Name == "Cherry");
            WeightedSymbol melon = symbols.Single(y => y.Name == "Melon");
            WeightedSymbol peach = symbols.Single(y => y.Name == "Peach");
            WeightedSymbol orange = symbols.Single(y => y.Name == "Orange");
            WeightedSymbol lemon = symbols.Single(y => y.Name == "Lemon");

            Assert.AreEqual(apple.Weight, 0.1);
            Assert.AreEqual(mango.Weight, 0.15);
            Assert.AreEqual(cherry.Weight, 0.2);
            Assert.AreEqual(melon.Weight, 0.15);
            Assert.AreEqual(peach.Weight, 0.1);
            Assert.AreEqual(orange.Weight, 0.2);
            Assert.AreEqual(lemon.Weight, 0.1);
        }
    }
}
