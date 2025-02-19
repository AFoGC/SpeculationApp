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
    public class ConvertationViewModelFactory : IViewModelFactory<ConvertationViewModel, ConvertationEntity>
    {
        private readonly MainCollectionService _mainCollectionService;

        public ConvertationViewModelFactory(MainCollectionService mainCollectionService)
        {
            _mainCollectionService = mainCollectionService;
        }

        public ConvertationViewModel CreateViewModel(ConvertationEntity model)
        {
            return new ConvertationViewModel(model);
        }
    }
}
