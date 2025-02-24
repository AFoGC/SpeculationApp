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
    public class PairViewModelFactory : IViewModelFactory<PairViewModel, PairModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public PairViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public PairViewModel CreateViewModel(PairModel model)
        {
            PairStrategy strategy = new PairStrategy(_unitOfWork, _mainCollectionService, model.BaseCurrencyId, model.TradeCurrencyId);
            return new PairViewModel(model, strategy);
        }
    }
}
