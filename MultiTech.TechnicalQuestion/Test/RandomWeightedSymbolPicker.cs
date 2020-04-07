using MultiTech.TechnicalQuestion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTech.TechnicalQuestion.Test
{
    public class RandomWeightedSymbolPicker
    {
        public IEnumerable<WeightedSymbol> Pick (IEnumerable<WeightedSymbol> weightedSymbols, int tries)
        {
            if (tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(tries), "Must be greater than 0.");

            // Calculate the total amount of weight
            double totalWeight = weightedSymbols.Sum(y => y.Weight);

            Random random = new Random();

            // Outer loop for the amount of tries
            for (int i = 0; i < tries; i++)
            {
                // Get a random number between the 0 and the max weight
                double randomValue = random.NextDouble() * totalWeight;

                // Loop through all the symbols and see if the random value is within the weight
                foreach (WeightedSymbol ws in weightedSymbols)
                {
                    if (randomValue < ws.Weight)
                    {
                        // The lucky symbol!
                        yield return ws;
                        break;
                    }
                    else
                    {
                        // If the value is not within the weight range, remove its weight from the total randomValue
                        // Otherwise it could be possible nothing is picked
                        randomValue -= ws.Weight;
                    }
                }
            } 
        }
    }
}
