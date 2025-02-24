using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Mapers;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class ConvertationRepository : IConvertationRepository
    {
        private readonly TradingContext _dbContext;
        private readonly ConvertationMaper _maper;

        public ConvertationRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new ConvertationMaper();
        }

        public IEnumerable<ConvertationModel> GetAll(int baseCurrencyId, int tradeCurrencyId)
        {
            return _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId)
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public ConvertationModel GetById(int id)
        {
            var item = _dbContext.Convertations
                .Single(x => x.Id == id);

            return _maper.MapEntity(item);
        }

        public void Create(ConvertationModel entity)
        {
            entity.Id = 0;

            var item = _maper.MapModel(entity);

            _dbContext.Convertations.Add(item);
        }

        public void Update(ConvertationModel entity)
        {
            var item = _maper.MapModel(entity);

            _dbContext.Convertations.Update(item);
        }

        public void Delete(int id)
        {
            var item = _dbContext.Convertations
                .Single(x => x.Id == id);

            _dbContext.Convertations.Remove(item);
        }

        public decimal GetBaseCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .Sum(x => x.BaseCurrencyAmount);

            decimal decreaseSum = _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .Sum(x => x.BaseCurrencyAmount);

            return increaseSum - decreaseSum;
        }

        public decimal GetTradeCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _dbContext.Convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .Sum(x => x.TradeCurrencyAmount);

            decimal decreaseSum = _dbContext.Convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .Sum(x => x.TradeCurrencyAmount);

            return increaseSum - decreaseSum;
        }
    }
}
