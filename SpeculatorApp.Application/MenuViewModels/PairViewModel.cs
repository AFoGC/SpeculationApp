using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Strategies;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class PairViewModel : ViewModel
    {
        private readonly PairEntity _pair;
        private readonly PairStrategy _strategy;

        public PairViewModel(PairEntity pair, PairStrategy strategy)
        {
            _pair = pair;
            _strategy = strategy;
        }

        public int BaseCurrencyId => _pair.BaseCurrencyId;
        public int TradeCurrencyId => _pair.TradeCurrencyId;
        public int PositionInList
        {
            get => _pair.PositionInList;
            set { _pair.PositionInList = value; OnPropertyChanged(); }
        }

        public CurrencyViewModel BaseCurrency => _strategy.GetCurrency(_pair.BaseCurrencyId);
        public CurrencyViewModel TradeCurrency => _strategy.GetCurrency(_pair.TradeCurrencyId);

        public IEnumerable<ConvertationViewModel> Convertations
        {
            get
            {
                return _strategy.Convertations.Convertations;
            }
        }
    }
}
