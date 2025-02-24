using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class OperationMaper : IMaper<Operation, OperationEntity>
    {
        public Operation MapDomainEntity(OperationEntity entity)
        {
            return new Operation
            {
                Id = entity.Id,
                CurrencyId = entity.CurrencyId,
                OperationTypeId = entity.OperationTypeId,
                Amount = entity.Amount,
                Date = entity.Date
            };
        }

        public OperationEntity MapEntity(Operation entity)
        {
            return new OperationEntity
            {
                Id = entity.Id,
                CurrencyId = entity.CurrencyId,
                OperationTypeId = entity.OperationTypeId,
                Amount = entity.Amount,
                Date = entity.Date
            };
        }
    }
}
