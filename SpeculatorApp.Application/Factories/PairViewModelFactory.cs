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
    public class PairViewModelFactory : IViewModelFactory<PairViewModel, PairEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public PairViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public PairViewModel CreateViewModel(PairEntity model)
        {
            PairStrategy strategy = new PairStrategy(_unitOfWork, _mainCollectionService, model.BaseCurrencyId, model.TradeCurrencyId);
            return new PairViewModel(model, strategy);
        }
    }
}
