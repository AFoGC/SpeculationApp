using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.ViewModels;
using SpeculatorApp.Application.Tables.Serivces;
using SpeculatorApp.Application.Tables.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.Factories
{
    public class ConvertationViewModelFactory : IViewModelFactory<ConvertationViewModel, ConvertationModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public ConvertationViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public ConvertationViewModel CreateViewModel(ConvertationModel model)
        {
            ConvertationStrategy strategy = new ConvertationStrategy(_unitOfWork, _mainCollectionService);
            return new ConvertationViewModel(model, strategy);
        }
    }
}
