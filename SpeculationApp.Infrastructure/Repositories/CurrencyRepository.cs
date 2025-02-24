using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Mapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly TradingContext _dbContext;
        private readonly CurrencyMaper _maper;

        public CurrencyRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new CurrencyMaper();
        }

        public IEnumerable<CurrencyModel> GetAll()
        {
            return _dbContext.Currencies
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public CurrencyModel GetById(int id)
        {
            var item = _dbContext.Currencies
                .Single(x => x.Id == id);

            return _maper.MapEntity(item);
        }

        public void Create(CurrencyModel entity)
        {
            entity.Id = 0;

            var item = _maper.MapModel(entity);

            _dbContext.Currencies.Add(item);
        }

        public void Update(CurrencyModel entity)
        {
            var item = _maper.MapModel(entity);

            _dbContext.Currencies.Update(item);
        }

        public void Delete(int id)
        {
            var item = _dbContext.Currencies
                .Single(x => x.Id == id);

            _dbContext.Currencies.Remove(item);
        }
    }
}
