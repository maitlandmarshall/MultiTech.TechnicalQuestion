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
    public class RandomWeightedSymbolPickerTests
    {
        [DataRow(5)]
        [DataRow(15)]
        [DataRow(25)]
        [DataTestMethod]
        public void Pick_WeightedSymbolCollectionFactory_ResultCountMatchesTries(int tries)
        {
            RandomWeightedSymbolPicker randomWeightedSymbolPicker = new RandomWeightedSymbolPicker();
            WeightedSymbolCollectionFactory weightedSymbolCollectionFactory = new WeightedSymbolCollectionFactory();

            IEnumerable<WeightedSymbol> weightedSymbols = weightedSymbolCollectionFactory.Create();
            List<WeightedSymbol> picks = randomWeightedSymbolPicker.Pick(weightedSymbols, tries).ToList();

            Assert.AreEqual(picks.Count, tries);
        }

        [DataRow(1000)]
        [DataRow(100)]
        [DataTestMethod]
        public void Pick_WeightedSymbolCollectionFactory_RandomPicksMatchesWeightDistribution(int tries)
        {
            RandomWeightedSymbolPicker randomWeightedSymbolPicker = new RandomWeightedSymbolPicker();
            WeightedSymbolCollectionFactory weightedSymbolCollectionFactory = new WeightedSymbolCollectionFactory();

            IEnumerable<WeightedSymbol> weightedSymbols = weightedSymbolCollectionFactory.Create();
            List<WeightedSymbol> picks = randomWeightedSymbolPicker.Pick(weightedSymbols, tries).ToList();

            var picksSymbolGroup = picks.GroupBy(y => y);

            foreach (var symbolGroup in picksSymbolGroup)
            {
                WeightedSymbol weightedSymbol = symbolGroup.Key;
                int symbolGroupCount = symbolGroup.Count();

                // What is the calculated weight of the symbol we actually picked with the random picker?
                double avgPickWeight = symbolGroupCount / (double)tries;

                // What is the actual predefined weight?
                double wsWeight = symbolGroup.Key.Weight;

                const double similarPcnt = 0.05;

                // The weights should be very similar. Let's say 5% similar.
                double wsWeightMin = wsWeight - wsWeight * similarPcnt;
                double wsWeightMax = wsWeight + wsWeight * similarPcnt;

                Assert.IsTrue(wsWeight >= wsWeightMin);
                Assert.IsTrue(wsWeight <= wsWeightMax);
            }

        }
    }
}
