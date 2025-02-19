using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class CurrencyViewModelFactory : IViewModelFactory<CurrencyViewModel, CurrencyEntity>
    {
        public CurrencyViewModel CreateViewModel(CurrencyEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
