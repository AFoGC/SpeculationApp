using SpeculationApp.Domain.Entities;
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

        public PairViewModel(PairEntity pair)
        {
            _pair = pair;
        }

        public int BaseCurrencyId => _pair.BaseCurrencyId;
        public int TradeCurrencyId => _pair.TradeCurrencyId;
        public int PositionInList
        {
            get => _pair.PositionInList;
            set { _pair.PositionInList = value; OnPropertyChanged(); }
        }
    }
}
