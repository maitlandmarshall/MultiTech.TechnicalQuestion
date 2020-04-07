using MultiTech.TechnicalQuestion.Domain;
using System.Collections.Generic;

namespace MultiTech.TechnicalQuestion.Test
{
    public class WeightedSymbolCollectionFactory
    {
        public IEnumerable<WeightedSymbol> Create()
        {
            return new List<WeightedSymbol>()
            {
                new WeightedSymbol { Name = "Apple", Weight = 0.1 },
                new WeightedSymbol { Name = "Mango", Weight = 0.15 },
                new WeightedSymbol { Name = "Cherry", Weight = 0.2 },
                new WeightedSymbol { Name = "Melon", Weight = 0.15 },
                new WeightedSymbol { Name = "Peach", Weight = 0.1 },
                new WeightedSymbol { Name = "Orange", Weight = 0.2 },
                new WeightedSymbol { Name = "Lemon", Weight = 0.1 }
            };
        }
    }
}
