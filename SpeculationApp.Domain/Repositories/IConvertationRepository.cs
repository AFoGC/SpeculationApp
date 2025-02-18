using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IConvertationRepository
    {
        IEnumerable<ConvertationEntity> GetAll(int baseCurrencyId, int tradeCurrencyId);
        ConvertationEntity GetById(int id);
        void Create(ConvertationEntity entity);
        void Update(ConvertationEntity entity);
        void Delete(int id);
        decimal GetBaseCurrencyAmount(int currencyId);
        decimal GetTradeCurrencyAmount(int currencyId);
    }
}
