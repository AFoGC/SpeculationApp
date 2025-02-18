using Microsoft.EntityFrameworkCore;
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
    public class PairRepository : IPairRepository
    {
        private readonly TradingContext _dbContext;
        private readonly PairMaper _maper;

        public PairRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new PairMaper();
        }

        public IEnumerable<PairEntity> GetAll()
        {
            return _dbContext.Pairs
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public PairEntity GetById(int baseCurrencyId, int tradeCurrencyId)
        {
            var item = _dbContext.Pairs
                .Single(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);

            return _maper.MapEntity(item);
        }

        public void Create(PairEntity entity)
        {
            var item = _maper.MapDomainEntity(entity);

            _dbContext.Pairs.Add(item);
        }

        public void Update(PairEntity entity)
        {
            var item = _maper.MapDomainEntity(entity);

            _dbContext.Pairs.Update(item);
        }

        public void Update(IEnumerable<PairEntity> entities)
        {
            var items = entities.Select(x => _maper.MapDomainEntity(x));

            _dbContext.Pairs.UpdateRange(items);
        }

        public void Delete(int baseCurrencyId, int tradeCurrencyId)
        {
            var item = _dbContext.Pairs
                .Single(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);

            _dbContext.Pairs.Remove(item);
        }
    }
}
