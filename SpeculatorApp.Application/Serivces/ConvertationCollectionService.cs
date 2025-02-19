using SpeculatorApp.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class ConvertationCollectionService
    {
        private readonly ConvertationViewModelFactory _factory;

        public ConvertationCollectionService(ConvertationViewModelFactory factory)
        {
            _factory = factory;
        }
    }
}
