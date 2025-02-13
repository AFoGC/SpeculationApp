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

        public IEnumerable<Convertation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Convertation> GetBaseCurrencyConvertations(int baseCurrencyId)
        {
            throw new NotImplementedException();
        }

        public Convertation GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Convertation> GetTradeCurrencyConvertations(int tradeCurrencyId)
        {
            throw new NotImplementedException();
        }

        public void Update(Convertation entity)
        {
            throw new NotImplementedException();
        }
    }
}
