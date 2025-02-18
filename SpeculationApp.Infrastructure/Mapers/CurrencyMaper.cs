using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class CurrencyMaper : IMaper<Currency, CurrencyEntity>
    {
        public Currency MapDomainEntity(CurrencyEntity entity)
        {
            throw new NotImplementedException();
        }

        public CurrencyEntity MapEntity(Currency entity)
        {
            throw new NotImplementedException();
        }
    }
}
