using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class ConvertationMaper : IMaper<Convertation, ConvertationEntity>
    {
        public Convertation MapDomainEntity(ConvertationEntity entity)
        {
            return new Convertation
            {
                Id = entity.Id,
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                BaseCurrencyAmount = entity.BaseCurrencyAmount,
                TradeCurrencyAmount = entity.TradeCurrencyAmount,
                ToTradeCurrency = entity.ToTradeCurrency,
                Date = entity.Date,
            };
        }

        public ConvertationEntity MapEntity(Convertation entity)
        {
            return new ConvertationEntity
            {
                Id = entity.Id,
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                BaseCurrencyAmount = entity.BaseCurrencyAmount,
                TradeCurrencyAmount = entity.TradeCurrencyAmount,
                ToTradeCurrency = entity.ToTradeCurrency,
                Date = entity.Date,
            };
        }
    }
}
