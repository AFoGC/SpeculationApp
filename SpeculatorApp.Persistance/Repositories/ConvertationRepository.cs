using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.Repositories
{
    public class ConvertationRepository : IConvertationRepository
    {
        public ConvertationRepository()
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConvertation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConvertation> GetBaseCurrencyConvertations(int baseCurrencyId)
        {
            throw new NotImplementedException();
        }

        public IConvertation GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConvertation> GetTradeCurrencyConvertations(int tradeCurrencyId)
        {
            throw new NotImplementedException();
        }

        public void Update(IConvertation entity)
        {
            throw new NotImplementedException();
        }
    }
}
