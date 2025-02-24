using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Tables.Serivces;
using SpeculatorApp.Application.Tables.Strategies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.ViewModels
{
    public class OperationViewModel : ViewModel
    {
        private readonly OperationEntity _operation;
        private readonly OperationStrategy _strategy;

        public OperationViewModel(OperationEntity operation, OperationStrategy strategy)
        {
            _operation = operation;
            _strategy = strategy;
        }

        public int Id => _operation.Id;
        public int CurrencyId => _operation.CurrencyId;
        public int OperationTypeId
        {
            get => _operation.OperationTypeId;
            set 
            { 
                _operation.OperationTypeId = value;
                _strategy.Update(_operation);
                OnPropertyChanged(); 
            }
        }
        public decimal Amount
        {
            get => _operation.Amount;
            set 
            { 
                _operation.Amount = value;
                _strategy.Update(_operation);
                OnPropertyChanged(); 
            }
        }
        public DateTime Date
        {
            get => _operation.Date; 
            set 
            { 
                _operation.Date = value;
                _strategy.Update(_operation);
                OnPropertyChanged(); 
            }
        }

        public OperationTypeViewModel SelectedOperationType
        {
            get
            {
                return _strategy.GetOperationType(_operation.OperationTypeId);
            }
            set
            {
                _operation.OperationTypeId = value.Id;
                _strategy.Update(_operation);

                OnPropertyChanged();
                OnPropertyChanged(nameof(OperationTypeId));
            }
        }
    }
}
