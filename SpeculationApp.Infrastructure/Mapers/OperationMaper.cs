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
            throw new NotImplementedException();
        }

        public OperationEntity MapEntity(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}
