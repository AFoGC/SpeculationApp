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
        private readonly CurrencyEntity _entity;
        private readonly IEnumerable<OperationEntity> _operations;

        public CurrencyModel(CurrencyEntity entity, IEnumerable<OperationEntity> operations)
        {
            _entity = entity;
            _operations = operations;
        }

        public CurrencyEntity CurrencyEntity => _entity;
        public IEnumerable<OperationEntity> Operations => _operations;
    }
}
