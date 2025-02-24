using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Models
{
    public class CurrencyModel
    {
        private readonly Entities.CurrencyModel _entity;
        private readonly IEnumerable<OperationModel> _operations;

        public CurrencyModel(Entities.CurrencyModel entity, IEnumerable<OperationModel> operations)
        {
            _entity = entity;
            _operations = operations;
        }

        public Entities.CurrencyModel CurrencyEntity => _entity;
        public IEnumerable<OperationModel> Operations => _operations;
    }
}
