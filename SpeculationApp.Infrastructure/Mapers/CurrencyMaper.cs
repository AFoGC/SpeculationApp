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
            return new Currency
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
            };
        }

        public CurrencyEntity MapEntity(Currency entity)
        {
            return new CurrencyEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
            };
        }
    }
}
