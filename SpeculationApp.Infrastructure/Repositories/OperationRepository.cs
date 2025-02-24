using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Entities;
using SpeculationApp.Infrastructure.Mapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly TradingContext _dbContext;
        private readonly OperationMaper _maper;

        public OperationRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new OperationMaper();
        }

        public IEnumerable<OperationModel> GetAll(int currencyId)
        {
            return _dbContext.Operations
                .Where(x => x.CurrencyId == currencyId)
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public OperationModel GetById(int id)
        {
            var item = _dbContext.Operations
                .Single(x => x.Id == id);

            return _maper.MapEntity(item);
        }

        public void Create(OperationModel entity)
        {
            entity.Id = 0;

            var item = _maper.MapModel(entity);

            _dbContext.Operations.Add(item);
        }

        public void Update(OperationModel entity)
        {
            var item = _maper.MapModel(entity);

            _dbContext.Operations.Update(item);
        }

        public void Delete(int id)
        {
            var item = _dbContext.Operations
                .Single(x => x.Id == id);

            _dbContext.Operations.Remove(item);
        }

        public decimal GetCurrencyAmount(int currencyId)
        {
            var query = _dbContext.Operations
                .Include(x => x.OperationType)
                .Where(x => x.CurrencyId == currencyId);

            decimal increaseSum = query
                .Where(x => x.OperationType.IsIncrease)
                .Sum(x => x.Amount);

            decimal decreaseSum = query
                .Where(x => x.OperationType.IsIncrease == false)
                .Sum(x => x.Amount);

            return increaseSum - decreaseSum;
        }
    }
}
