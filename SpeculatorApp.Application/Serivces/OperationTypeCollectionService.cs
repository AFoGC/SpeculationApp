using SpeculatorApp.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class OperationTypeCollectionService
    {
        private readonly OperationTypeViewModelFactory _factory;

        public OperationTypeCollectionService(OperationTypeViewModelFactory factory)
        {
            _factory = factory;
        }
    }
}
