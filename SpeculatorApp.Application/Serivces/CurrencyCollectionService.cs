using SpeculatorApp.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class CurrencyCollectionService
    {
        private readonly CurrencyViewModelFactory _factory;

        public CurrencyCollectionService(CurrencyViewModelFactory factory)
        {
            _factory = factory;
        }
    }
}
