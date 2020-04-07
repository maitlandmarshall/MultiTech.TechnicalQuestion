using Microsoft.AspNetCore.Mvc;
using MultiTech.TechnicalQuestion.Test;
using MultiTech.TechnicalQuestion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTech.TechnicalQuestion.Controllers
{
    [ApiController]    
    [Route("api/randomSymbolPicker")]
    public class RandomWeightedSymbolPickerController : ControllerBase
    {
        private readonly RandomWeightedSymbolPicker randomWeightedSymbolPicker;
        private readonly WeightedSymbolCollectionFactory weightedSymbolCollectionFactory;

        public RandomWeightedSymbolPickerController(RandomWeightedSymbolPicker randomWeightedSymbolPicker,
                                                    WeightedSymbolCollectionFactory weightedSymbolCollectionFactory)
        {
            this.randomWeightedSymbolPicker = randomWeightedSymbolPicker;
            this.weightedSymbolCollectionFactory = weightedSymbolCollectionFactory;
        }

        [HttpGet("pick/{x}")]
        public string PickRandomWeightedSymbol (int x)
        {
            IEnumerable<WeightedSymbol> symbols = this.randomWeightedSymbolPicker.Pick(this.weightedSymbolCollectionFactory.Create(), x);

            return String.Join(Environment.NewLine, symbols.Select(y => y.Name));
        }
    }
}
