using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.MenuViewModels;
using SpeculatorApp.Application.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class PairViewModelFactory : IViewModelFactory<PairViewModel, PairEntity>
    {
        private readonly MainCollectionService _mainCollectionService;

        public PairViewModelFactory(MainCollectionService mainCollectionService)
        {
            _mainCollectionService = mainCollectionService;
        }

        public PairViewModel CreateViewModel(PairEntity model)
        {
            var baseCurrency = _mainCollectionService.CurrencyCollection.Currencies
                .Single(x => x.Id == model.BaseCurrencyId);

            var tradeCurrency = _mainCollectionService.CurrencyCollection.Currencies
                .Single(x => x.Id == model.TradeCurrencyId);

            return new PairViewModel(model, baseCurrency, tradeCurrency);
        }
    }
}
