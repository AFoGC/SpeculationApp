using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.MenuViewModels;
using SpeculatorApp.Application.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class OperationViewModelFactory : IViewModelFactory<OperationViewModel, OperationEntity>
    {
        private readonly MainCollectionService _mainCollectionService;

        public OperationViewModelFactory(MainCollectionService mainCollectionService)
        {
            _mainCollectionService = mainCollectionService;
        }

        public OperationViewModel CreateViewModel(OperationEntity model)
        {
            var operationTypes = _mainCollectionService.OperationTypeCollection;
            return new OperationViewModel(operationTypes, model);
        }
    }
}
