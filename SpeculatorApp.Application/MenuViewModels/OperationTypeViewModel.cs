using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.MenuViewModels
{
    public class OperationTypeViewModel : ViewModel
    {
        private readonly OperationTypeEntity _operationType;

        public OperationTypeViewModel(OperationTypeEntity operationType)
        {
            _operationType = operationType;
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
