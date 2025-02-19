using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class OperationTypeViewModelFactory : IViewModelFactory<OperationTypeViewModel, OperationTypeEntity>
    {

        
        public OperationTypeViewModelFactory()
        {

        }

        public OperationTypeViewModel CreateViewModel(OperationTypeEntity model)
        {
            return new OperationTypeViewModel(model);
        }
    }
}
