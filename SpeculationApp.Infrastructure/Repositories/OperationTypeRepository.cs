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
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly TradingContext _dbContext;
        private readonly OperationTypeMaper _maper;

        public OperationTypeRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new OperationTypeMaper();
        }

        public IEnumerable<OperationTypeEntity> GetAll()
        {
            return _dbContext.OperationTypes
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public OperationTypeEntity GetById(int id)
        {
            var item = _dbContext.OperationTypes
                .Single(x => x.Id == id);

            return _maper.MapEntity(item);
        }

        public void Create(OperationTypeEntity entity)
        {
            entity.Id = 0;

            var item = _maper.MapDomainEntity(entity);

            _dbContext.OperationTypes.Add(item);
        }

        public void Update(OperationTypeEntity entity)
        {
            var item = _maper.MapDomainEntity(entity);

            _dbContext.OperationTypes.Update(item);
        }

        public void Delete(int id)
        {
            var item = _dbContext.Convertations
                .Single(x => x.Id == id);

            _dbContext.Convertations.Remove(item);
        }
    }
}
