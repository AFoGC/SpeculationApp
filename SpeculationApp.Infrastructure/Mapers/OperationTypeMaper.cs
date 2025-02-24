using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class OperationTypeMaper : IMaper<OperationType, OperationTypeEntity>
    {
        public OperationType MapDomainEntity(OperationTypeEntity entity)
        {
            return new OperationType
            {
                Id = entity.Id,
                Name = entity.Name,
                IsIncrease = entity.IsIncrease,
            };
        }

        public OperationTypeEntity MapEntity(OperationType entity)
        {
            return new OperationTypeEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                IsIncrease = entity.IsIncrease,
            };
        }
    }
}
