﻿using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class ConvertationViewModel : ViewModel
    {
        private readonly ConvertationEntity _convertation;

        public ConvertationViewModel(ConvertationEntity convertation)
        {
            _convertation = convertation;
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
