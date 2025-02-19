using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class PairViewModelFactory : IViewModelFactory<PairViewModel, PairEntity>
    {
        public PairViewModel CreateViewModel(PairEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
