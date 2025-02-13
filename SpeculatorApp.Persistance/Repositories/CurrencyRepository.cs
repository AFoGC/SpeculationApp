using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Currency> GetAll()
        {
            throw new NotImplementedException();
        }

        public decimal GetBaseCurrencyAmount(int baseCurrencyId)
        {
            throw new NotImplementedException();
        }

        public Currency GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public decimal GetOperationsAmount(int currencyId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTradeCurrencyAmount(int tradeCurrencyId)
        {
            throw new NotImplementedException();
        }

        public void Update(Currency entity)
        {
            throw new NotImplementedException();
        }
    }
}
