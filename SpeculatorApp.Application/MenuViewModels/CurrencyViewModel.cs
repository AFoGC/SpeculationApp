using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Serivces;
using SpeculatorApp.Application.Strategies;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class CurrencyViewModel : ViewModel
    {
        private readonly CurrencyEntity _currency;
        private readonly CurrencyStrategy _strategy;

        public CurrencyViewModel(CurrencyEntity currency, CurrencyStrategy strategy)
        {
            _currency = currency;
            _strategy = strategy;
        }

        public int Id => _currency.Id;
        public string Code
        {
            get => _currency.Code;
            set { _currency.Code = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _currency.Name;
            set { _currency.Name = value; OnPropertyChanged(); }
        }
        public decimal TotalAmount
        {
            get => _strategy.TotalAmount;
        }

        public IEnumerable<OperationViewModel> Operations
        {
            get
            {
                return _strategy.Operations.Operations;
            }
        }
    }
}
