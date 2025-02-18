using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class PairMaper : IMaper<Pair, PairEntity>
    {
        public Pair MapDomainEntity(PairEntity entity)
        {
            throw new NotImplementedException();
        }

        public PairEntity MapEntity(Pair entity)
        {
            throw new NotImplementedException();
        }
    }
}
