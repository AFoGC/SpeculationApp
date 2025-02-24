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
            return new Pair
            {
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                PositionInList = entity.PositionInList,
            };
        }

        public PairEntity MapEntity(Pair entity)
        {
            return new PairEntity
            {
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                PositionInList = entity.PositionInList,
            };
        }
    }
}
