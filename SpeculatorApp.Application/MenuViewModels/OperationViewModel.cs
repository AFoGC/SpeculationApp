using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Serivces;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class OperationViewModel : ViewModel
    {
        private readonly OperationEntity _operation;
        private readonly OperationTypeCollectionService _operationTypes;

        public OperationViewModel(OperationTypeCollectionService operationTypes, OperationEntity operation)
        {
            _operationTypes = operationTypes;
            _operation = operation;
        }

        public int Id => _operation.Id;
        public int CurrencyId => _operation.CurrencyId;
        public int OperationTypeId
        {
            get => _operation.OperationTypeId;
            set { _operation.OperationTypeId = value; OnPropertyChanged(); }
        }
        public decimal Amount
        {
            get => _operation.Amount;
            set { _operation.Amount = value; OnPropertyChanged(); }
        }
        public DateTime Date
        {
            get => _operation.Date; 
            set { _operation.Date = value; OnPropertyChanged(); }
        }

        public OperationTypeViewModel OperationType
        {
            get
            {
                return _operationTypes.OperationTypes.Single(x => x.Id == _operation.OperationTypeId);
            }
        }
    }
}
