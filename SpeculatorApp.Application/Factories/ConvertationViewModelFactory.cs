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
    public class ConvertationViewModelFactory : IViewModelFactory<ConvertationViewModel, ConvertationEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public ConvertationViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public ConvertationViewModel CreateViewModel(ConvertationEntity model)
        {
            ConvertationStrategy strategy = new ConvertationStrategy(_unitOfWork, _mainCollectionService);
            return new ConvertationViewModel(model, strategy);
        }
    }
}
