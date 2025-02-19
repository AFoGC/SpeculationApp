using SpeculatorApp.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class PairCollectionService
    {
        private PairViewModelFactory _factory;

        public PairCollectionService(PairViewModelFactory factory)
        {
            _factory = factory;
        }
    }
}
