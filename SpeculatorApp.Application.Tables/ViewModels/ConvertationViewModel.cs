using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Tables.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.ViewModels
{
    public class ConvertationViewModel : ViewModel
    {
        private readonly ConvertationEntity _convertation;
        private readonly ConvertationStrategy _strategy;

        public ConvertationViewModel(ConvertationEntity convertation, ConvertationStrategy strategy)
        {
            _convertation = convertation;
            _strategy = strategy;
        }

        public int Id => _convertation.Id;
        public int BaseCurrencyId => _convertation.BaseCurrencyId;
        public int TradeCurrencyId => _convertation.TradeCurrencyId;
        public decimal BaseCurrencyAmount
        {
            get => _convertation.BaseCurrencyAmount;
            set { _convertation.BaseCurrencyAmount = value; OnPropertyChanged(); }
        }
        public decimal TradeCurrencyAmount
        {
            get => _convertation.TradeCurrencyAmount;
            set { _convertation.TradeCurrencyAmount = value; OnPropertyChanged(); }
        }
        public bool ToTradeCurrency
        {
            get => _convertation.ToTradeCurrency;
            set { _convertation.ToTradeCurrency = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _convertation.Date;
            set { _convertation.Date = value; OnPropertyChanged(); }
        }
    }
}
