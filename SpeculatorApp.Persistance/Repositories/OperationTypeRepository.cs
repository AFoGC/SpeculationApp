using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.Repositories
{
    public class OperationTypeRepository : IOperationRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IOperation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IOperation GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IOperation entity)
        {
            throw new NotImplementedException();
        }
    }
}
