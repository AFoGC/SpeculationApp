using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Tables.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.ViewModels
{
    public class OperationTypeViewModel : ViewModel
    {
        private readonly OperationTypeModel _operationType;
        private readonly OperationTypeStrategy _strategy;

        public OperationTypeViewModel(OperationTypeModel operationType, OperationTypeStrategy strategy)
        {
            _operationType = operationType;
            _strategy = strategy;
        }

        public int Id => _operationType.Id;
        public string Name
        {
            get => _operationType.Name;
            set
            { 
                _operationType.Name = value;
                _strategy.Update(_operationType);
                OnPropertyChanged(); 
            }
        }
        public bool IsIncrease
        {
            get => _operationType.IsIncrease;
            set 
            { 
                _operationType.IsIncrease = value;
                _strategy.Update(_operationType);
                OnPropertyChanged(); 
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
