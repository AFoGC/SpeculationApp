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
    public class OperationViewModelFactory : IViewModelFactory<OperationViewModel, OperationEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public OperationViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public OperationViewModel CreateViewModel(OperationEntity model)
        {
            OperationStrategy strategy = new OperationStrategy(_unitOfWork, _mainCollectionService);
            return new OperationViewModel(model, strategy);
        }
    }
}
