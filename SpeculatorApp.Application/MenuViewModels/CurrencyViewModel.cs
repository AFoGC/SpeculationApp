using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Serivces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly CurrencyEntity _currency;
        private readonly CurrencyOperations _operations;

        public CurrencyViewModel(IUnitOfWork unitOfWork, CurrencyEntity currency, CurrencyOperations operations)
        {
            _unitOfWork = unitOfWork;
            _currency = currency;
            _operations = operations;
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
            get => 0;
        }

        public IEnumerable<OperationViewModel> Operations
        {
            get
            {
                return _operations.Operations;
            }
        }
    }
}
