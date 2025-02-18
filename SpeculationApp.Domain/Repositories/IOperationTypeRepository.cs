using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IOperationTypeRepository
    {
        IEnumerable<OperationTypeEntity> GetAll();
        OperationTypeEntity GetById(int id);
        void Create(OperationTypeEntity entity);
        void Update(OperationTypeEntity entity);
        void Delete(int id);
    }
}
