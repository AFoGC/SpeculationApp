using SpeculationApp.Application.Tables.ViewModels;
using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Application.Tables.ViewModels.ReadViewModel
{
    public class PairReadViewModel : ViewModel
    {
        private readonly CurrencyReadViewModel _baseCurrency;
        private readonly CurrencyReadViewModel _tradeCurrency;

        private PairModel _model;

        public PairReadViewModel(PairModel model, CurrencyReadViewModel baseCurrency, CurrencyReadViewModel tradeCurrency)
        {
            _baseCurrency = baseCurrency;
            _tradeCurrency = tradeCurrency;

            _model = model;
        }

        public int BaseCurrencyId => _model.BaseCurrencyId;
        public int TradeCurrencyId => _model.TradeCurrencyId;
        public int PositionInList
        {
            get => _model.PositionInList;
            set
            {
                _model.PositionInList = value;
                OnPropertyChanged();
            }
        }

        public CurrencyReadViewModel BaseCurrency => _baseCurrency;
        public CurrencyReadViewModel TradeCurrency => _tradeCurrency;
    }
}
