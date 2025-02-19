using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.MenuViewModels;
using SpeculatorApp.Application.Serivces;
using SpeculatorApp.Application.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class OperationTypeViewModelFactory : IViewModelFactory<OperationTypeViewModel, OperationTypeEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public OperationTypeViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public OperationTypeViewModel CreateViewModel(OperationTypeEntity model)
        {
            OperationTypeStrategy strategy = new OperationTypeStrategy(_unitOfWork, _mainCollectionService);
            return new OperationTypeViewModel(model, strategy);
        }
    }
}
