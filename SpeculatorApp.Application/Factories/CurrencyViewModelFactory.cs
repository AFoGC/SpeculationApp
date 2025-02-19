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
    public class CurrencyViewModelFactory : IViewModelFactory<CurrencyViewModel, CurrencyEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MainCollectionService _mainCollectionService;

        public CurrencyViewModelFactory(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService)
        {
            _unitOfWork = unitOfWork;
            _mainCollectionService = mainCollectionService;
        }

        public CurrencyViewModel CreateViewModel(CurrencyEntity model)
        {
            CurrencyStrategy strategy = new CurrencyStrategy(_unitOfWork, _mainCollectionService, model.Id);
            return new CurrencyViewModel(model, strategy);
        }
    }
}
