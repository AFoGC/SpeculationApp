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
        private readonly OperationTypeEntity _operationType;
        private readonly OperationTypeStrategy _strategy;

        public OperationTypeViewModel(OperationTypeEntity operationType, OperationTypeStrategy strategy)
        {
            _operationType = operationType;
            _strategy = strategy;
        }

        public int Id => _operationType.Id;
        public string Name
        {
            get => _operationType.Name;
            set { _operationType.Name = value; OnPropertyChanged(); }
        }
        public bool IsIncrease
        {
            get => _operationType.IsIncrease;
            set { _operationType.IsIncrease = value; OnPropertyChanged(); }
        }
    }
}
