using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IOperationRepository
    {
        IEnumerable<OperationEntity> GetAll(int currencyId);
        OperationEntity GetById(int id);
        void Create(OperationEntity entity);
        void Update(OperationEntity entity);
        void Delete(int id);
        decimal GetCurrencyAmount(int currencyId);
    }
}
